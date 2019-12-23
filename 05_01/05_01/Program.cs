using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


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



            do
            {

                DataProvider.DeSerialized();
                Thread.Sleep(2000);
                Console.WriteLine($"---");
                //foreach (var item in Watcher.BackupList)
                //{

                //    Console.WriteLine($"{item.Key}, {item.Value.FullPath}, {item.Value.Content}");
                //}
            } while (true);

        }
    }
}
