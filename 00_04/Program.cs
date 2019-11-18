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
                    Console.Write("{0},", array[i][j]);
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
            Console.WriteLine("Enter N");
            int array_size = int.Parse(Console.ReadLine());
            int[][] array = new int[array_size][];
            for (int i = 0; i < array_size; i++)
            {
                int array_line_size = int.Parse(Console.ReadLine());
                array[i] = new int[array_line_size];
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
