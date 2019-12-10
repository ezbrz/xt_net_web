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
                ShowPeople(LostPeople);
                HidePeople(LostPeople);
            } while (LostPeople.Count > 1);
            
            ShowPeople(LostPeople);
            Console.ReadKey();
            
        }
        static void ShowPeople(List<People> list)
        {
            Console.WriteLine("\nNow in round:");
            foreach(var elem in list)
            {
                Console.Write($"{elem.PeopleCharacteristic}, ");
            }
        }
        static void HidePeople(List<People> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 != 0) { list.RemoveAt(i); }
            }
        }
    }
    class People
    {
        private string _name;
        private string _surName;

        public string Name
        {
            get => _name;
            set
            {
                if (value.Length > 0) { _name = value; } else { throw new ArgumentException("Invalid first name", "name"); }
            }
        }
        public string Surname
        {
            get => _surName;
            set
            {
                if (value.Length > 0) { _surName = value; } else { throw new ArgumentException("Invalid first name", "name"); }
            }
        }

        public People(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string PeopleCharacteristic
        {
            get => $"{this.Name} {this.Surname}";
        }
    }
}
