using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_01
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine($"Square = {GetValue(out _, "A") * GetValue(out _, "B")}");
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

    }
}
