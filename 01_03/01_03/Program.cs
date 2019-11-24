using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_03
{
    class Program
    {
        static void Main(string[] args)
        {
            writeLineN(GetValue(out _, "N"));
            Console.ReadKey();
        }

        static int GetValue(out int val, string valName)
        {
            Console.WriteLine($"Please, enter {valName}");
            do
            {
                int.TryParse(Console.ReadLine(), out val);
                if (val <= 0) Console.WriteLine($"incorrect {valName}, try again. {valName} must  be > 0");
            } while (val <= 0);
            return val;
        }

        static void writeLineN(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(new string(' ', n-i)+new string('*',i*2-1));
            }
        }
    }
}
