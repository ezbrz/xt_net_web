using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07_01
{
    static class Number
    {
        public static void GetNumberType(string input)
        {
            Regex regexSimpleNotation = new Regex(@"^[-]?\d+([\.]\d+)?$");
            Regex regexScienceNotation = new Regex(@"^[-]?[1-9](\.\d+[1-9]|\.[1-9])?e[-]?[1-9](\d+)?$");
            if (regexScienceNotation.IsMatch(input))
            {
                Console.WriteLine("Number in scientific notation");
            }
            else if (regexSimpleNotation.IsMatch(input))
            {
                Console.WriteLine("Number in simple notation");
            }
            else
            {
                Console.WriteLine("This is not number");
            }
        }
    }
}
