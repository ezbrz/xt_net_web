using Epam._06_01.BLL;
using Epam._06_01.BLL.Interfaces;
using Epam._06_01.DAL;
using Epam._06_01.DAO.Interfaces;
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
        private static IUserLogic _userLogic;
        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDAO));

        static DependencyResolver()
        {
            var dataReadConfig = GetLogic("DataMode");
            if (dataReadConfig == "XML")
            {
                UserDAO = new UserXmlDAO();
            }else if (dataReadConfig == "Memory")
            {
                UserDAO = new UserFakeDAO();
            }
            else
            {
                throw new Exception("Can't start application");
            }
        }
        public static string GetLogic(string input)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                return appSettings[input] ?? "Error";
            }
            catch (ConfigurationErrorsException)
            {
                return "Error";
            }
        }
        public static void SwitchLogic(string input)
        {
            try
            {
                var appSettings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = appSettings.AppSettings.Settings;
                if (settings[input].Value == "XML") 
                {
                    settings[input].Value = "Memory"; 
                } else if (settings[input].Value == "Memory")
                {
                    settings[input].Value = "XML";
                } else
                {
                    settings[input].Value = "XML";
                }
                appSettings.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(appSettings.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
