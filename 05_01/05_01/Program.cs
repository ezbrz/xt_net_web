using System;
using System.Threading;


namespace _05_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 'q' to quit the programm.");
            string path = @"D:\Test\";
            Thread th = new Thread(Watcher.Run);
            th.Start(path);


            DateTime result;
            string param;
            do
            {
                Console.WriteLine($"Choose some data to restore your files. Format will be the same like {DateTime.Now.ToString()}");
                param = Console.ReadLine();
                if (DateTime.TryParse(param, out result))
                {
                    th.Abort();
                    Restore.RestoreFiles(result, path);
                }


            } while (param != "q");
            th.Abort();
        }
    }
}
