using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_07
{
    class Program
    {
        static void Main(string[] args)
        {
            try { 
            Line NewLIne = new Line(new Point(10, 15), 56, 10);
            NewLIne.GetInfo();
            Circle NewCircle = new Circle(new Point(7, 7), 8);
            NewCircle.GetInfo();
            Round NewRound = new Round(new Point(1, -5), 4);
            NewRound.GetInfo();
            Ring NewRing = new Ring(new Point(1, -5), 5, 1);
            NewRing.GetInfo();
            Square NewSquare = new Square(new Point(109, 53), 5, 90);
            NewSquare.GetInfo();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
