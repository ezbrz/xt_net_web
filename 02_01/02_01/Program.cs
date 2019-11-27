using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter radius:");
            int.TryParse(Console.ReadLine(), out int r);
            Console.WriteLine("Enter coordinates. X and Y:");
            int.TryParse(Console.ReadLine(), out int x);
            int.TryParse(Console.ReadLine(), out int y);
            try
            {
                Round NewRound = new Round(new Point(x, y), r);
                Console.WriteLine(NewRound.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            
            Console.ReadKey();
        }
    }


}
