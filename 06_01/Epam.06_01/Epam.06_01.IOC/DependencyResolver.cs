﻿using Epam._06_01.BLL;
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

        private static IUserLogic _userLogic;
        private static IAwardLogic _awardLogic;
        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDAO));
        public static IAwardLogic AwardLogic => _awardLogic ?? (_awardLogic = new AwardLogic(AwardDAO));

        static DependencyResolver()
        {
            var dataReadConfig = DataMode.GetLogic("DataMode");
            if (dataReadConfig == "XML")
            {
                UserDAO = new UserXmlDAO();
                AwardDAO = new AwardXMLDAO();
            }else if (dataReadConfig == "Memory")
            {
                UserDAO = new UserFakeDAO();
                AwardDAO = new AwardFakeDAO();
            }
            else
            {
                throw new Exception("Can't start application");
            }
        }
        
    }
}
