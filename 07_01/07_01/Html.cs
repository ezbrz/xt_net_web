using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07_01
{
    static class Html
    {
        public static string ReplaceHTML(string input)
        {
            Regex regex = new Regex(@"\b<.+?>\b");
            return regex.Replace(input, "_");
        }
    }
}
