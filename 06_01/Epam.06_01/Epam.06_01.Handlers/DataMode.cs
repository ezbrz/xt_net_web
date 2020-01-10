﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.Handlers
{
    public class DataMode
    {
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
                }
                else if (settings[input].Value == "Memory")
                {
                    settings[input].Value = "XML";
                }
                else
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
        public static string GetPath(string input)
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
    }
}
