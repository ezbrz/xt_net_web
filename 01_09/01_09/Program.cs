using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_09
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[50];
            PullArray(arr);
            ShowArray(arr);
            Console.Write($"\nSum non-negative elements = {SumNonNegative(arr)}");
            Console.ReadKey();
        }

        static void PullArray(int[] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-500, 500);
            }
        }

        static void ShowArray(int[] arr)
        {
            foreach (int elem in arr)
            {
                Console.Write($"{elem} ");
            }
        }
        static bool IsPositive(int i)
        {
            if (i > 0) return true; else return false;
        }
        static int SumNonNegative(int[] arr)
        {
            int sumNonNegative=0;
            foreach (int elem in arr)
            {
                if (IsPositive(elem)) sumNonNegative += elem;
            }
            return sumNonNegative;
        }
    }
}
