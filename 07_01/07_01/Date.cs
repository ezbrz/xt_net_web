using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07_01
{
    static class Date
    {
        private static bool IsDateExist(string input)
        {
            Regex regex = new Regex(@"\b(3[01]|[0-2][0-9])-(1[0-2]|0[0-9])-\d{4}\b");
            Match match = regex.Match(input);
            if (match.Success && DateTime.TryParse(match.Value, out _))
            {
                return true;
            }
            return false;
        }

        public static void DateContain(string input)
        {
            if (IsDateExist(input))
            {
                Console.WriteLine(@"Text {input} include date");
            }
            else
            {
                Console.WriteLine(@"Text {input} don't include date");
            }
        }
    }
}
