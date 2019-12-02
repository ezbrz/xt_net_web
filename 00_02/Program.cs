using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int simpleNum = 0;
            do
            {
                Console.WriteLine("Enter N");
            } while(!int.TryParse(Console.ReadLine(), out simpleNum));
            if (IsSimple(simpleNum)) { Console.WriteLine($"{simpleNum} is a simple number"); } else { Console.WriteLine($"{simpleNum} isn't a simple number"); }
            Console.ReadKey();
        }
        static Boolean IsSimple(int simpleNumber)
        {
            if (simpleNumber == 1 | simpleNumber == 2 | simpleNumber == 5) { return true; }
            else
            {
                if ((simpleNumber % 10) % 2 == 0 | (simpleNumber % 10) == 5) { return false; }
                else
                {
                    for (int i = 3; i <= Math.Round(Math.Sqrt(simpleNumber)); i += 2)
                    {
                        if (simpleNumber % i == 0) { return false; }
                    }
                }
                return true;
            }
        }
    }

}
