using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string patronymic;
            string surname;
            DateTime birthdate;
            try
            {
                Console.WriteLine("Enter name, patronymic, surname, dirthdate");

                while (true)
                {
                    name = Console.ReadLine();
                    if (name!=null&&name.Length!=0)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid name input. Try again.");
                }
                while (true)
                {
                    patronymic = Console.ReadLine();
                    if (patronymic != null && patronymic.Length != 0)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid patronymic input. Try again.");
                }
                while (true)
                {
                    surname = Console.ReadLine();
                    if (surname != null && surname.Length != 0)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid surname input. Try again.");
                }

                while (true)
                {
                    if (DateTime.TryParse(Console.ReadLine(), out birthdate))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid date input. Try again.");
                }

                User NewUser = new User(name, surname, patronymic, birthdate);
                Console.WriteLine(NewUser.ToString());

                Console.WriteLine("Enter new birthday:");
                while (true)
                {
                    if (DateTime.TryParse(Console.ReadLine(), out birthdate))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid date input. Try again.");
                }
                NewUser.UserBirthdate = birthdate;
                Console.WriteLine(NewUser.ToString());

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
