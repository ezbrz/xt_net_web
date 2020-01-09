using Epam._06_01.BLL.Interfaces;
using Epam._06_01.Entities;
using Epam._06_01.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.ConsolePL
{
    class StartPage
    {
        private static uint _userId;
        public static void Run(IUserLogic logic)
        {
            for (; ; ) 
            {
                Console.Clear();
                Console.WriteLine($"Use commands:\nMode - change data mode\nGetAllUsers - show all users\nUser - show user with current id\nDelete <id> - delete user with current id\nAdd - add new user\nExit - quit from application");
                string choose = Console.ReadLine();
                if (choose == "Exit")
                {
                    return;
                }
                switch (choose)
                {
                    case "GetAllUsers":
                        foreach (var item in logic.GetAll())
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadKey();
                        break;
                    case "Mode":
                        Console.WriteLine($"Current mode {DependencyResolver.GetLogic("DataMode")} will changed");
                        DependencyResolver.SwitchLogic("DataMode");
                        Console.WriteLine($"New mode {DependencyResolver.GetLogic("DataMode")}. This mode will work after restart of application");
                        Console.ReadKey();
                        break;
                    case "User":
                        Console.WriteLine("Enter user id");
                        uint.TryParse(Console.ReadLine(), out _userId);
                        Console.WriteLine(logic.GetById(_userId));
                        Console.ReadKey();
                        break;
                    case "Delete":
                        Console.WriteLine("Enter user id");
                        uint.TryParse(Console.ReadLine(), out _userId);
                        if (logic.DeleteById(_userId))
                        {
                            Console.WriteLine($"User with id = {_userId} deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine($"Can't delete user with id = {_userId}!");
                        }
                        Console.ReadKey();
                        break;
                    case "Add":
                        Console.WriteLine("Enter new user name");
                        string _newUserName = Console.ReadLine();
                        Console.WriteLine("Enter new user birthday");
                        DateTime.TryParse(Console.ReadLine(), out DateTime _userBirthday);
                        if (logic.Add(new User() {Name = _newUserName, DateOfBirth = _userBirthday}))
                        {
                            Console.WriteLine("User added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Can't create new user!");
                        }
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            }
            
        }
        
    }
}
