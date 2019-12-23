using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _05_01
{
    static class DataProvider
    {
        static public string GetFileContent(string path)
        {
            int numberOfTries = 0;
            while (true)
            {
                try
                {
                    using (FileStream readFileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader read = new StreamReader(readFileStream, true))
                        {
                            string content = read.ReadToEnd();
                            return content;
                        }
                    }
                }
                catch (IOException ex)
                {
                    if (numberOfTries++ == 10)
                        throw new IOException(ex.Message, ex.InnerException);
                }
            }
        }
        static public void Serialized()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(@"D:\Test\log.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Watcher.BackupList);

                Console.WriteLine("Объект сериализован");
            }
        }
        static public void DeSerialized()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(@"D:\Test\log.dat", FileMode.OpenOrCreate))
            {
                Watcher.BackupList = (Dictionary<DateTime, FileChangeInfo>)formatter.Deserialize(fs);

                foreach (var item in Watcher.BackupList)
                {
                    Console.WriteLine($"Date/Time: {item.Key} --- Changed file: {item.Value.Name} --- Change mode: {item.Value.ChangeFileMode}");
                }
            }
        }
    }
}
