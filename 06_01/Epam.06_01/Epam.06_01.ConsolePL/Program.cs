using Epam._06_01.BLL;
using Epam._06_01.Entities;
using Epam._06_01.IOC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu.Run(DependencyResolver.UserLogic, DependencyResolver.AwardLogic);
        }
    }
}
