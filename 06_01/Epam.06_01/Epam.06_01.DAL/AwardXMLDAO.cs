using Epam._06_01.DAO.Interfaces;
using Epam._06_01.Entities;
using Epam._06_01.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Epam._06_01.DAL
{
    public class AwardXMLDAO : IAwardDAO
    {
        private static Dictionary<uint, Award> _awards = new Dictionary<uint, Award>();
        private static bool _edited = true;
        static readonly string path = DataMode.GetPath("AwardFile");

        public bool Add(Award award)
        {
            if (_edited) { GetAll(); }
            try
            {
                var lastId = _awards.Keys.Count > 0
                ? _awards.Keys.Max()
                : 0;
                award.Id = lastId + 1;
                _awards.Add(award.Id, award);
                var root = XMLProvider.XmlConnect(path);
                XmlNode xRoot = root.DocumentElement;
                XmlNode newRecord = root.CreateElement("award");
                XmlAttribute recordAttribute = root.CreateAttribute("id");
                XmlNode recordName = root.CreateElement("name");
                XmlText newName = root.CreateTextNode(award.Name);
                XmlText newId = root.CreateTextNode(award.Id.ToString());

                recordName.AppendChild(newName);
                recordAttribute.AppendChild(newId);
                newRecord.AppendChild(recordName);
                newRecord.Attributes.Append(recordAttribute);
                xRoot.AppendChild(newRecord);
                XMLProvider.XmlSave(root, path);
                _edited = false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Award> GetAll()
        {
            _awards.Clear();
            var root = XMLProvider.XmlConnect(path);
            XmlNode xRoot = root.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                Award award = new Award();
                XmlNode attr = xnode.Attributes.GetNamedItem("id");
                if (attr != null)
                {
                    uint.TryParse(attr.Value, out uint id);
                    award.Id = id;
                }
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "name")
                        award.Name = childnode.InnerText;
                }
                _awards.Add(award.Id, award);
            }
            _edited = false;
            return _awards.Values;
        }
        public Award GetById(uint id)
        {
            if (_edited)
            {
                return GetAll().FirstOrDefault(s => s.Id == id);
            }
            return _awards.FirstOrDefault(s => s.Key == id).Value;
        }
        public bool DeleteById(uint id)
        {
            try
            {
                var root = XMLProvider.XmlConnect(path);
                XmlNode xRoot = root.DocumentElement;
                XmlNode node = xRoot.SelectSingleNode(string.Format("award[@id = '{0}']", id));
                XmlNode outer = node.ParentNode;
                outer.RemoveChild(node);
                if (!XMLProvider.XmlSave(root,path)) return false;
                _edited = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditById(uint id, string newValue, byte[] photo)
        {
            try
            {
                var root = XMLProvider.XmlConnect(path);
                XmlNode xRoot = root.DocumentElement;
                XmlNode node = xRoot.SelectSingleNode(string.Format("award[@id = '{0}']", id));
                node.SelectSingleNode("name").InnerText = newValue;
                if (!XMLProvider.XmlSave(root, path)) return false;
                _edited = true;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
