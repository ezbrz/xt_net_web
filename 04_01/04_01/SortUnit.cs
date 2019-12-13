using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_01
{
    class SortUnit
    {
        static int _threadCount = 0;
        public static event Action<string> OnSort = delegate { };
        public static void SortEventHandler(string s)
        {
            _threadCount++;
            Console.WriteLine(s);
        }
        public static void SortArrayInThread()
        {
            OnSort += SortEventHandler;

            
            new Thread(() =>
            {
                int length = 15;
                Random rnd = new Random();
                int[] IntArray = new int[length];
                for (int i = 0; i < IntArray.Length; i++)
                {
                    IntArray[i] = rnd.Next(0, 100);
                }
                Thread.Sleep(5000);
                SortHandler.SortArray(IntArray, (a, b) => a > b);
                OnSort?.Invoke("\nSorting is complete INT\n");
                
            }).Start();
            new Thread(() =>
            {
                int length = 15;
                Random rnd = new Random();
                double[] DoubleArray = new double[length];
                for (int i = 0; i < DoubleArray.Length; i++)
                {
                    DoubleArray[i] = rnd.NextDouble() * 100;
                }
                Thread.Sleep(5000);
                SortHandler.SortArray(DoubleArray, (a, b) => a > b);
                OnSort?.Invoke("\nSorting is complete DOUBLE\n");
            }).Start();
            new Thread(() =>
            {
                string[] StringArray = new string[]
            {
                "afg", "uydd", "fjsfgfg", "adddd", "jddgfg", "bag", "lklolkl"
            };
                Thread.Sleep(5000);
                SortHandler.SortArray(StringArray, (a, b) => (!SortHandler.CompareString(a, b)));
                OnSort?.Invoke("\nSorting is complete STRING\n");
            }).Start();
            new Thread(() =>
            {
                while (_threadCount != 3)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("Sorting...");
                };
            }).Start();

        }

    }
}
