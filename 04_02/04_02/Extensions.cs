using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_02
{
    static class Extensions
    {
        public static double MySum(this int[] array)
        {
            double result = 0;
            foreach (var elem in array)
            {
                result += elem;
            }
            return result;
        }
        public static double MySum(this double[] array)
        {
            double result = 0;
            foreach (var elem in array)
            {
                result += elem;
            }
            return result;
        }
        public static double MySum(this byte[] array)
        {
            double result = 0;
            foreach (var elem in array)
            {
                result += elem;
            }
            return result;
        }
        public static double MySum(this float[] array)
        {
            double result = 0;
            foreach (var elem in array)
            {
                result += elem;
            }
            return result;
        }
        public static double MySum(this uint[] array)
        {
            double result = 0;
            foreach (var elem in array)
            {
                result += elem;
            }
            return result;
        }
        public static bool IsNum(this string str)
        {
            if (str == null || str.Length == 0) { return false; }
            str.Trim();
            foreach (var elem in str)
            {
                if (!Char.IsDigit(elem)) { return false; }
            }
            return true;
        }
    }
}

