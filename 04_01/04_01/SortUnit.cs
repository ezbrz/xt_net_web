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
        public delegate void SortDelegate(Array arr);
        public static event SortDelegate OnSort;

        public static void SortArray<T>(T[] array, Func<T, T, bool> order)
        {
            if (order == null)
            {
                throw new ArgumentException("Invalid compare method");
            }
            if (array == null)
            {
                throw new ArgumentException("Invalid array");
            }
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i; j < array.Length; j++)
                    if (order(array[j], array[i]))
                    {
                        Switch<T>(ref array[i], ref array[j]);
                    }
            }
            OnSort += delegate { Console.WriteLine("Sorting is finished\n"); };
            OnSort += new SortDelegate(ShowArray);
            OnSort?.Invoke(array);
            OnSort = null;
        }

        public static void Switch<T>(ref T t1, ref T t2)
        {
            T temp = t1;
            t1 = t2;
            t2 = temp;
        }
        public static void ShowArray(Array array)
        {
            foreach (var elem in array)
            {
                Console.Write($"{elem}, ");
            }
            Console.WriteLine();
        }
        public static void SortArrayInThread()
        {
            new Thread(() =>
            {
                int length = 15;
                Random rnd = new Random();
                int[] IntArray = new int[length];
                for (int i = 0; i < IntArray.Length; i++)
                {
                    IntArray[i] = rnd.Next(0, 100);
                }
                //Custom sort
                SortArray(IntArray, (a, b) => a > b);
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
                //Custom sort
                SortArray(DoubleArray, (a, b) => a > b);
            }).Start();
            new Thread(() =>
            {
                string[] StringArray = new string[]
            {
                "afg", "uydd", "fjsfgfg", "adddd", "jddgfg"
            };
                SortArray(StringArray, (a, b) => a.Length >= b.Length);
            }).Start();
        }
        public static void CustomSort()
        {
            int length = 15;
            Random rnd = new Random();
            int[] IntArray = new int[length];
            for (int i = 0; i < IntArray.Length; i++)
            {
                IntArray[i] = rnd.Next(0, 100);
            }
            //Custom sort
            SortArray(IntArray, (a, b) => a > b);
        }
        public static void CustomSortDouble()
        {
            int length = 15;
            Random rnd = new Random();
            double[] DoubleArray = new double[length];
            for (int i = 0; i < DoubleArray.Length; i++)
            {
                DoubleArray[i] = rnd.NextDouble()*100;
            }
            //Custom sort
            SortArray(DoubleArray, (a, b) => a > b);
        }
        public static void CustomSortDemo()
        {
            string[] StringArray = new string[]
            {
                "afg", "uydd", "fjsfgfg", "adddd", "jddgfg"
            };
            //Custom sort demo (with string)
            SortArray(StringArray, (a, b) => a.Length >= b.Length);
        }
    }
}
