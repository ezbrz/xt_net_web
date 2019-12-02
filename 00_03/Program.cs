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
            int squareNum = 0;
            do
            {
                Console.WriteLine("Enter N");
            } while (!int.TryParse(Console.ReadLine(), out squareNum)||(squareNum%2==0));
            GetSquare(squareNum);
            Console.ReadKey();
        }
        static void GetSquare(int squareNum)
        {
            int middle = (squareNum / 2) + 1;
            for (int i = 1; i <= squareNum; i++)
            {
                for (int j = 1; j <= squareNum; j++)
                {
                    if (i == middle && j == middle && i == j) { Console.Write(" "); } else { Console.Write("*"); }
                }
                Console.WriteLine();
            }
        }
    }
}
