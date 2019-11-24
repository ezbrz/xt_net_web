using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_05
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum=0;
            for (int i=1; i<=1000; i++)
            {
                if (isValid(i)) sum += i;
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }

        static bool isValid(int n)
        {
            if (n % 3==0 || n % 5==0) return true; else return false;
        }


    }
}
