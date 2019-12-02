using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter slave string:");
            string primaryStr = Console.ReadLine();
            Console.WriteLine("Enter master string:");
            string secondaryStr = Console.ReadLine();
            Console.WriteLine(DoubleChar(primaryStr, secondaryStr));

            Console.ReadKey();
        }
        static string DoubleChar(string firstStr, string secondStr)
        {
            StringBuilder primaryStrBuilder = new StringBuilder();
            foreach (char elem in firstStr)
            {
                if (secondStr.Contains(elem)) primaryStrBuilder.Append(elem,2); else primaryStrBuilder.Append(elem, 1);
            }
            return primaryStrBuilder.ToString();
        }
    }
}
