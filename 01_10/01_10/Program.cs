using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_10
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] arr = new int[15,15];
            PullArray(arr);
            ShowArray(arr);
            Console.WriteLine($"Summ even elements = {GetSum(arr)}");
            Console.ReadKey();
        }
        static void PullArray(int[,] arr)
        {
            Random rnd = new Random();
            for (int i = 1; i < arr.GetLength(0); i++)
            {
                for (int j = 1; j < arr.GetLength(1); j++)
                {
                    arr[i,j] = rnd.Next(-500, 500);
                }
            }
        }

        static void ShowArray(int[,] arr)
        {
            for (int i = 1; i < arr.GetLength(0); i++)
            {
                for (int j = 1; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j], 5}");
                }
                Console.Write("\n");
            }
        }
        static int GetSum(int[,] arr)
        {
            int sumElem = 0;
            for (int i = 1; i < arr.GetLength(0); i++)
            {
                for (int j = 1; j < arr.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0) sumElem += arr[i, j];
                }
            
            }
        return sumElem;
        }
    }
}
