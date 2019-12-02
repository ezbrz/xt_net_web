using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02
{
    class Program
    {
        static void Main(string[] args)
        {
            
            writeLineN(TakeValue("N"));
            Console.ReadKey();   
        }
        static void writeLineN(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(new string('*', i));
            }
        }

        static int TakeValue(string valName)
        {
            int val = 0;
            Console.WriteLine($"Please, enter {valName}");
            do
            {
                int.TryParse(Console.ReadLine(), out val);
                if (val <= 0) Console.WriteLine($"incorrect {valName}, try again. {valName} must  be > 0");
            } while (val <= 0);
            return val;
        }
    }
}
