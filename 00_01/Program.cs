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
            int sequence_num = int.Parse(Console.ReadLine());
            Sequence currentSequence = new Sequence();
            currentSequence.GetSequence(sequence_num);
            Console.ReadKey();
        }
    }

    public class Sequence
    {
        public void GetSequence(int sequence_number)
        {
            Console.Write(1);
            if (sequence_number > 1)
            {
                for (int i = 2; i <= sequence_number; i++)
                {
                    Console.Write(", " + i);
                }
            }
        }
    }
}
