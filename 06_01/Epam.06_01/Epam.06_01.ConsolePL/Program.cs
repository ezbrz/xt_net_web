using Epam._06_01.BLL;
using Epam._06_01.Entities;
using Epam._06_01.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            var logic = DependencyResolver.UserLogic;

            var current = logic.Add(new User()
            {
                Name = "Ivan",
                DateOfBirth = new DateTime(1990,12,07),
                Age = 13,
            });

            foreach (var item in logic.GetAll())
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
