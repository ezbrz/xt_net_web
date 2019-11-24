using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_07
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[100];
            PullArray(arr);
            ShowArray(arr);
            Console.WriteLine($"\nMinimal value: {GetVal(arr, SearchType.min)}\nMaximum value: {GetVal(arr, SearchType.max)}");
            SortArray(arr);
            ShowArray(arr);
            Console.ReadKey();
        }

        static void PullArray(int[] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i<arr.Length; i++)
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

        static int GetVal(int[] arr, SearchType sType)
        {
            int val = arr[0];
                switch (sType)
                {
                    case SearchType.min:
                    foreach (int elem in arr)
                    {
                        if (elem < val) val = elem;
                    }
                    break;
                    case SearchType.max:
                    foreach (int elem in arr)
                    {
                        if (elem > val) val = elem;
                    }
                    break;
                }
        return val;
        }
       
        static void SortArray(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int cur = arr[i];
                int j = i;
                while (j > 0 && cur < arr[j - 1])
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = cur;
            }
        }
        enum SearchType
        {
            min,
            max
        }
    }
}
