using Epam._06_01.BLL;
using Epam._06_01.BLL.Interfaces;
using Epam._06_01.DAL;
using Epam._06_01.DAO.Interfaces;
using Epam._06_01.Handlers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.IOC
{
    public static class DependencyResolver
    {

        public static IUserDAO UserDAO;
        public static IAwardDAO AwardDAO;
        public static IAuthUserDAO AuthUserDAO;

        private static IUserLogic _userLogic;
        private static IAwardLogic _awardLogic;
        private static IAuthUserLogic _authUserLogic;
        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDAO));
        public static IAwardLogic AwardLogic => _awardLogic ?? (_awardLogic = new AwardLogic(AwardDAO));
        public static IAuthUserLogic AuthUserLogic => _authUserLogic ?? (_authUserLogic = new AuthUserLogic(AuthUserDAO));

        static DependencyResolver()
        {
            var dataReadConfig = DataMode.GetLogic("DataMode");
            switch (dataReadConfig)
            {
                case "XML":
                    UserDAO = new UserXmlDAO();
                    AwardDAO = new AwardXMLDAO();
                    break;
                case "Memory":
                    UserDAO = new UserFakeDAO();
                    AwardDAO = new AwardFakeDAO();
                    break;
                case "DB":
                    UserDAO = new UserDbDAO();
                    AwardDAO = new AwardDbDAO();
                    break;
                default:
                    UserDAO = new UserFakeDAO();
                    AwardDAO = new AwardFakeDAO();
                    break;
            }
            AuthUserDAO = new AuthUserDAO();
        }
        
    }
}
