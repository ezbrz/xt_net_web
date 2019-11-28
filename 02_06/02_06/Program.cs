using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_06
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter outer and inner radiuses:");
                int.TryParse(Console.ReadLine(), out int outerr);
                int.TryParse(Console.ReadLine(), out int innerr);
                Console.WriteLine("Enter coordinates of center. X and Y:");
                int.TryParse(Console.ReadLine(), out int x);
                int.TryParse(Console.ReadLine(), out int y);

                Circle NewCircle = new Circle(new Point(x, y), outerr, innerr);

                Console.WriteLine(NewCircle.ToString());

                Console.WriteLine("Let's change inner radius");
                int.TryParse(Console.ReadLine(), out innerr);
                NewCircle.InnerRadius = innerr;
                Console.WriteLine(NewCircle.ToString());

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
