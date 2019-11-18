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
            int simple_num = int.Parse(Console.ReadLine());
            Simple simpleNum = new Simple();

            if (simpleNum.GetSimple(simple_num)) { Console.WriteLine(simple_num + " is a simple number"); } else { Console.WriteLine(simple_num + " isn't a simple number"); }
            Console.ReadKey();
        }
    }

    public class Simple
    {
        public Boolean GetSimple(int simple_number)
        {
            if (simple_number == 1 | simple_number == 2 | simple_number == 5) { return true; }
            else
            {
                if ((simple_number % 10) % 2 == 0 | (simple_number % 10) == 5) { return false; }
                else
                {
                    for (int i = 3; i <= Math.Round(Math.Sqrt(simple_number)); i += 2)
                    {
                        if (simple_number % i == 0) { return false; }
                    }
                }
                return true;
            }
        }
    }
}
