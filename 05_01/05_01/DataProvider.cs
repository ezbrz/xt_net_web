using System;
using System.Collections.Generic;
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
                    if (numberOfTries++ == 5)
                        throw new IOException(ex.Message, ex.InnerException);
                }
            }
        }
        static public void Serialized(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(path+"log.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Watcher.BackupList);
            }
        }
        static public void DeSerialized(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(path+"log.dat", FileMode.OpenOrCreate))
            {
                Watcher.BackupList = (Dictionary<DateTime, FileChangeInfo>)formatter.Deserialize(fs);

                foreach (var item in Watcher.BackupList)
                {
                    Console.WriteLine($"Date/Time: {item.Key} --- Changed file: {item.Value.Name} --- Change mode: {item.Value.ChangeFileMode}");
                }
            }
        }
        public static void FirstStart(string path)
        {
            ProcessDirectory(path);
        }
        public static void ProcessDirectory(string path)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(path, "*.txt");
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(path);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);

            Serialized(path);
        }
        public static void ProcessFile(string path)
        {
            string content;
            string fileName;
            content = GetFileContent(path);
            fileName = Path.GetFileName(path);
            FileChangeInfo FileLog = new FileChangeInfo(fileName, path, "", DateTime.Now, WatcherChangeTypes.Created, content, content);
            Watcher.BackupList.Add(DateTime.Now, FileLog);
        }
    }
}
