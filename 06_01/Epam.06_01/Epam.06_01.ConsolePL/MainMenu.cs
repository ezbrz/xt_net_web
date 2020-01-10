using Epam._06_01.BLL.Interfaces;
using Epam._06_01.Entities;
using Epam._06_01.Handlers;
using Epam._06_01.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.ConsolePL
{
    class MainMenu
    {
        private static uint _userId;
        private static uint _awardId;
        public static void Run(IUserLogic userLogic, IAwardLogic awardLogic)
        {
            for (; ; ) 
            {
                Console.Clear();
                Console.WriteLine($"Use commands:\nMode - change data mode\nGetAllUsers - show all users\nUser - show user with current id\nDeleteUser - delete user with current id\nAddUser - add new user");
                Console.WriteLine($"GetAllAwards - show all Awards\nAward - show user with current id\nDeleteAward -delete user with current id\nAddAward - add new user\nExit - quit from application");
                string choose = Console.ReadLine();
                if (choose == "Exit")
                {
                    return;
                }
                switch (choose)
                {
                    case "Mode":
                        Console.WriteLine($"Current mode {DataMode.GetLogic("DataMode")} will changed");
                        DataMode.SwitchLogic("DataMode");
                        Console.WriteLine($"New mode {DataMode.GetLogic("DataMode")}. This mode will work after restart of application");
                        Console.ReadKey();
                        break;
                    case "GetAllUsers":
                        foreach (var item in userLogic.GetAll())
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadKey();
                        break;
                    case "GetAllAwards":
                        foreach (var item in awardLogic.GetAll())
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadKey();
                        break;
                    case "User":
                        Console.WriteLine("Enter user id");
                        uint.TryParse(Console.ReadLine(), out _userId);
                        Console.WriteLine(userLogic.GetById(_userId));
                        if (userLogic.GetUserAwards(_userId).Any())
                        {
                            Console.WriteLine("Awards:");
                            foreach (uint item in userLogic.GetUserAwards(_userId))
                            {
                                Console.WriteLine(awardLogic.GetById(item));
                            }
                        }
                        Console.ReadKey();
                        break;
                    case "Award":
                        Console.WriteLine("Enter award id");
                        uint.TryParse(Console.ReadLine(), out _awardId);
                        Console.WriteLine(awardLogic.GetById(_awardId));
                        Console.ReadKey();
                        break;
                    case "DeleteUser":
                        Console.WriteLine("Enter user id");
                        uint.TryParse(Console.ReadLine(), out _userId);
                        if (userLogic.DeleteById(_userId))
                        {
                            Console.WriteLine($"User with id = {_userId} deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine($"Can't delete user with id = {_userId}!");
                        }
                        Console.ReadKey();
                        break;
                    case "DeleteAward":
                        Console.WriteLine("Enter award id");
                        uint.TryParse(Console.ReadLine(), out _awardId);
                        if (awardLogic.DeleteById(_awardId))
                        {
                            Console.WriteLine($"Award with id = {_awardId} deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine($"Can't delete award with id = {_awardId}!");
                        }
                        Console.ReadKey();
                        break;
                    case "AddUser":
                        Console.WriteLine("Enter new user name");
                        string _newUserName = Console.ReadLine();
                        Console.WriteLine("Enter new user birthday");
                        DateTime.TryParse(Console.ReadLine(), out DateTime _userBirthday);
                        if (userLogic.Add(new User() {Name = _newUserName, DateOfBirth = _userBirthday}))
                        {
                            Console.WriteLine("User added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Can't create new user!");
                        }
                        Console.ReadKey();
                        break;
                    case "AddAward":
                        Console.WriteLine("Enter new award name");
                        string _newAwardName = Console.ReadLine();
                        if (awardLogic.Add(new Award() { Name = _newAwardName }))
                        {
                            Console.WriteLine("Award added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Can't create new award!");
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
