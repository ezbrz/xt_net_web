using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter new string:");
            string str = Console.ReadLine();
            Console.WriteLine(MidString(str));
            Console.ReadKey();
        }
        static string MidString(string str)
        {
            float wordLength = 0;
            float wordCount = 0;
            for (int i=0; i<str.Length; i++)
            {
                if (Char.IsLetter(str[i])) {
                    while (i < str.Length && Char.IsLetter(str[i]))
                    {
                        wordLength++;
                        i++;
                    }
                    wordCount++;
                }
            }
            if (wordCount == 0) return "Words not found"; else return (wordLength / wordCount).ToString();
        }
    }
}
