using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] MyStringArray = new string[] { "435", "dfd77", "jsdhf7", "878787f", "9988", "090", "8748" };
            uint[] MyArray = new uint[] { 7, 45, 23, 11, 22, 1 };
            Console.WriteLine(MyArray.MySum());
            foreach (var elem in MyStringArray)
            {
                Console.WriteLine(elem.IsNum());
            }
            Console.ReadLine();
        }
    }
}
