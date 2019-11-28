using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_04
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString abc = new MyString(Console.ReadLine());
            MyString def = new MyString(Console.ReadLine());
            MyString hhh = MyString.Append(abc, def);
            
            Console.WriteLine(hhh.ToString());
            Console.WriteLine(hhh.Length);
            Console.WriteLine(MyString.IsEqual(abc, def));
            Console.WriteLine(abc.FindChar('j'));
            Console.ReadKey();
        }
    }
}
