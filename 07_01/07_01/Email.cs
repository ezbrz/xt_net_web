using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07_01
{
    static class Email
    {
        public static void EmailValidator(string input)
        {
            Regex regex = new Regex(@"\b[a-zA-Z0-9][\w\.\-]*[a-zA-Z0-9]\@([a-zA-Z0-9][a-zA-Z0-9\-]*[a-zA-Z0-9][.])*[a-zA-Z]{2,6}\b");
            MatchCollection matches = regex.Matches(input);
            foreach (var item in matches)
            {
                Console.WriteLine(item);
            }
        }
    }
}
