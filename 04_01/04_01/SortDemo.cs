using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_01
{
    static class SortDemo
    {
        public delegate bool CompareStringDelegate(string[] str);
        public static void CustomSortIntDemo()
        {
            int length = 15;
            Random rnd = new Random();
            int[] IntArray = new int[length];
            for (int i = 0; i < IntArray.Length; i++)
            {
                IntArray[i] = rnd.Next(0, 100);
            }
            SortHandler.SortArray(IntArray, (a, b) => a > b);
        }
        public static void CustomSortDoubleDemo()
        {
            int length = 15;
            Random rnd = new Random();
            double[] DoubleArray = new double[length];
            for (int i = 0; i < DoubleArray.Length; i++)
            {
                DoubleArray[i] = rnd.NextDouble() * 100;
            }
            SortHandler.SortArray(DoubleArray, (a, b) => a > b);
        }
        public static void CustomSortStringDemo()
        {
            string[] StringArray = new string[]
            {
                "afg", "uydd", "fjsfgfg", "adddd", "jddgfg", "bag", "lklolkl"
            };
            SortHandler.SortArray(StringArray, (a,b)=>(!SortHandler.CompareString(a,b)));
        }
    }
}
