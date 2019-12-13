using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_01
{
    class PeopleHandler
    {
        public static void ShowPeople(List<People> list)
        {
            Console.WriteLine("\nNow in round:");
            foreach (var elem in list)
            {
                Console.Write($"{elem.PeopleCharacteristic}, ");
            }
        }
        public static void HidePeople(List<People> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 != 0) { list.RemoveAt(i); }
            }
        }
    }
}
