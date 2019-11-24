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
            
            writeLineN(GetValue(out _, "N"));
            Console.ReadKey();   
        }
        static void writeLineN(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(new string('*', i));
            }
        }

        static int GetValue(out int val, string valName)
        {
            Console.WriteLine($"Please, enter {valName}");
            do
            {
                
                int.TryParse(Console.ReadLine(), out val);
                if (val <= 0) Console.WriteLine("incorrect {0}, try again. {0} must  be > 0", valName);
            } while (val <= 0);
            return val;
        }
    }
}
