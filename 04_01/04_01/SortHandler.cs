using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_01
{
    static class SortHandler
    {

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
        }
        private static void Switch<T>(ref T t1, ref T t2)
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
        public static bool CompareString(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return str1.Length > str2.Length;
            }

            for(int i=0; i<str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    return str1[i]>str2[i];
                }
            }
            return false;
        }
    }
}
