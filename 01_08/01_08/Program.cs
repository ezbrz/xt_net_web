using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_08
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] arr = new int[10, 10, 10];
            PullArray(arr);
            ShowArray(arr);
            NoPositive(arr);
            ShowArray(arr);
            Console.ReadKey();

        }
        static void PullArray(int[,,] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        arr[i, j, k] = rnd.Next(-500, 500);
                    }
                }
            }
        }
        static void NoPositive(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        if (IsPositive(arr[i, j, k])) arr[i, j, k] = 0;
                    }
                }
            }
        }
        static bool IsPositive(int i)
        {
            if (i > 0) return true; else return false;
        }
        static void ShowArray(int[,,] arr)
        {

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        Console.WriteLine($"{i} {j} {k} = {arr[i, j, k]}");
                    }
                }
            }
        }
    }
}
