using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_02
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter sides of triangle: a, b, c:");
                int.TryParse(Console.ReadLine(), out int a);
                int.TryParse(Console.ReadLine(), out int b);
                int.TryParse(Console.ReadLine(), out int c);
                Triangle NewTriangle = new Triangle(new Side(a, b, c));
                Console.WriteLine(NewTriangle.ToString());

                Console.WriteLine("Enter new sides of triangle: a, b, c:");
                int.TryParse(Console.ReadLine(), out a);
                int.TryParse(Console.ReadLine(), out b);
                int.TryParse(Console.ReadLine(), out c);
                NewTriangle.TriangleSides=new Side(a, b, c);
                Console.WriteLine(NewTriangle.ToString());

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
