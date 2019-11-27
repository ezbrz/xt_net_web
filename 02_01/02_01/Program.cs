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
            try
            {
                Console.WriteLine("Round must be in I quater of coordinate plane(radius must be less then x coordinate and y coordinate)\nEnter radius:");
                int.TryParse(Console.ReadLine(), out int r);
                Console.WriteLine("Enter coordinates of center. X and Y:");
                int.TryParse(Console.ReadLine(), out int x);
                int.TryParse(Console.ReadLine(), out int y);

                Round NewRound = new Round(new Point(x, y), r);

                Console.WriteLine(NewRound.ToString());

                Console.WriteLine("Let's change radius");
                int.TryParse(Console.ReadLine(),out r);
                NewRound.RoundRadius = r;
                Console.WriteLine(NewRound.ToString());

                Console.WriteLine("Let's change coordinates of center");
                int.TryParse(Console.ReadLine(), out x);
                int.TryParse(Console.ReadLine(), out y);
                NewRound.CenterPoint = new Point(x, y);
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
