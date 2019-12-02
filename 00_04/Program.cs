using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_04
{
    class Program
    {

        public static void ShowArray(int[][] array)
        {
            Console.Write("{");
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write("{");
                for (int j = 0; j < array[i].Length; ++j)
                {
                    Console.Write($"{array[i][j]},");
                }
                Console.Write("},");
            }
            Console.Write("}");
        }

        public static void ArraySort(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Array.Sort(array[i]);
            }

        }

        static void Main(string[] args)
        {
            int arraySize = 0;
            int arrayLineSize = 0;
            do
            {
                Console.WriteLine("Enter array size of jagged array");
            } while (!int.TryParse(Console.ReadLine(), out arraySize)||arraySize==0);
            
            int[][] array = new int[arraySize][];
            for (int i = 0; i < arraySize; i++)
            {
                do
                {
                    Console.WriteLine($"Enter length of {i} array");
                } while (!int.TryParse(Console.ReadLine(), out arrayLineSize) || arrayLineSize == 0);
                array[i] = new int[arrayLineSize];
            }

            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = rnd.Next(0, 100);
                }
            }

            Console.WriteLine("unsorted array");
            ShowArray(array);
            ArraySort(array);
            Console.WriteLine();
            Console.WriteLine("sorted array");
            ShowArray(array);

            Console.ReadKey();
        }
    }


}
