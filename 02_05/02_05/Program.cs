using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_05
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string patronymic;
            string surname;
            DateTime birthdate;
            string position;
            int expirience;
            try
            {
                Console.WriteLine("Enter name, patronymic, surname, dirthdate, position, expirience");

                while (true)
                {
                    name = Console.ReadLine();
                    if (name != null && name.Length != 0)
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
                while (true)
                {
                    position = Console.ReadLine();
                    if (position != null && position.Length != 0)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid position input. Try again.");
                }
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out expirience))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid expirience input. Try again.");
                }

                Employee NewEmployee = new Employee(name, surname, patronymic, birthdate, position, expirience);
                Console.WriteLine(NewEmployee.ToString());

                Console.WriteLine("Enter new expirience:");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out expirience))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid expirience input. Try again.");
                }
                NewEmployee.EmployeeExpirience = expirience;
                Console.WriteLine(NewEmployee.ToString());

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
