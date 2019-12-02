using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceNum = 0;
            do
            {
                Console.WriteLine("Enter N");
            } while (!int.TryParse(Console.ReadLine(),out sequenceNum));
            
            GetSequence(sequenceNum);
            Console.ReadKey();
        }
        static void GetSequence(int sequenceNumber)
        {
            Console.Write(1);
            if (sequenceNumber > 1)
            {
                for (int i = 2; i <= sequenceNumber; i++)
                {
                    Console.Write(", " + i);
                }
            }
        }
    }
}
