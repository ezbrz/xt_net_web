using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07_01
{
    static class Time
    {
        public static int TimeCount(string input)
        {
            Regex regex = new Regex(@"\b(([01]?\d|2[0-3]):[0-5]\d|24:00)\b");
            MatchCollection matches = regex.Matches(input);
            return matches.Count;
        }
    }
}
