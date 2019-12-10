using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,uint> StackDictionary = GetFreqWord(FindWord(Console.ReadLine()));
            foreach (var elem in StackDictionary)
            {
                Console.WriteLine(elem);
            }
            Console.ReadKey();
        }
        static List<string> FindWord(string str)
        {
            List<string> listDictionary = new List<string>();
            StringBuilder strb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsLetter(str[i]))
                {
                    strb.Clear();
                    while (i < str.Length && Char.IsLetter(str[i]))
                    {
                        strb.Append(str[i]);
                        i++;
                    }
                    listDictionary.Add(strb.ToString().ToLower());
                }
            }
            listDictionary.Sort();
           return listDictionary;
        }
        static Dictionary<string, uint> GetFreqWord(List<string> list)
        {
            Dictionary<string, uint> stackDictionary = new Dictionary<string, uint>();
            foreach (var elem in list)
            {
                try
                {
                    stackDictionary.Add(elem, 1);
                }
                catch (ArgumentException)
                {
                    stackDictionary[elem]++;
                }
            }
            return stackDictionary;
        }
    }
}
