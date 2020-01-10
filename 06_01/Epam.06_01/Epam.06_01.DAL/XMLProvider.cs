using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Epam._06_01.DAL
{
    static class XMLProvider
    {
        public static XmlDocument XmlConnect(string path)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);
                return xDoc;
            }
            catch
            {
                throw new Exception("Something wrong with file");
            }

        }
        public static bool XmlSave(XmlDocument xDoc, string path)
        {
            try
            {
                xDoc.Save(path);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
