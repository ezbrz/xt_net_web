using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            //Date.DateContain(s);
            //Console.WriteLine(Html.ReplaceHTML(s));
            //Email.EmailValidator(s);
            //Number.GetNumberType(s);
            Console.WriteLine(Time.TimeCount(s));
            Console.ReadKey();
        }
    }
}
