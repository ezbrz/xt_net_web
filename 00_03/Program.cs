using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int square_num = int.Parse(Console.ReadLine());
            Square newSquare = new Square();
            newSquare.GetSquare(square_num);

            Console.ReadKey();
        }
    }

    public class Square
    {
        public void GetSquare(int square_num)
        {
            int middle = (int)(square_num / 2) + 1;
            for (int i = 1; i <= square_num; i++)
            {
                for (int j = 1; j <= square_num; j++)
                {
                    if (i == middle && j == middle && i == j) { Console.Write(" "); } else { Console.Write("*"); }
                }
                Console.WriteLine();
            }
        }
    }
}
