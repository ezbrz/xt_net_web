using Epam._06_01.BLL;
using Epam._06_01.BLL.Interfaces;
using Epam._06_01.DAL;
using Epam._06_01.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.IOC
{
    public static class DependencyResolver
    {
        private static IUserDAO _userDAO;
        public static IUserDAO UserDAO => _userDAO ?? (_userDAO = new UserDAO());

        private static IUserLogic _userLogic;
        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDAO));
    }
}
