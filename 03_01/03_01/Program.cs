using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> LostPeople = new List<People>()
            {
                new People("Alexey","Ivanov"),
                new People("Ivan","Alexeev"),
                new People("Sergey","Petrov"),
                new People("Petr","Sergeev"),
                new People("Nikolay","Sidorov"),
                new People("Maksim","Nikolaev"),
                new People("Roman","Zemskov"),
                new People("Alexandr","Kurnosov"),
                new People("Stanislav","Lobanov")
            };
            do
            {
                PeopleHandler.ShowPeople(LostPeople);
                PeopleHandler.HidePeople(LostPeople);
            } while (LostPeople.Count > 1);

            PeopleHandler.ShowPeople(LostPeople);
            Console.ReadKey();
            
        }

    }
}
