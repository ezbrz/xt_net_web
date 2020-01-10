﻿using Epam._06_01.DAO.Interfaces;
using Epam._06_01.Entities;
using Epam._06_01.Handlers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Epam._06_01.DAL
{
    public class UserXmlDAO : IUserDAO
    {
        private static Dictionary<uint, User> _users = new Dictionary<uint, User>();
        private static bool _edited = true;
        static readonly string path = DataMode.GetPath("UserFile");

        public bool Add(User user)
        {
            if (_edited) { GetAll(); }
            try 
            {
                var lastId = _users.Keys.Count > 0
                ? _users.Keys.Max()
                : 0;
                user.Id = lastId + 1;
                _users.Add(user.Id, user);
                var root = XMLProvider.XmlConnect(path);
                XmlNode xRoot = root.DocumentElement;
                XmlNode newRecord = root.CreateElement("user");
                XmlAttribute recordAttribute = root.CreateAttribute("id");
                XmlNode recordName = root.CreateElement("name");
                XmlNode recordBirthday = root.CreateElement("birthday");
                XmlText newName = root.CreateTextNode(user.Name);
                XmlText newBirthday = root.CreateTextNode(user.DateOfBirth.ToShortDateString());
                XmlText newId = root.CreateTextNode(user.Id.ToString());


                recordName.AppendChild(newName);
                recordAttribute.AppendChild(newId);
                recordBirthday.AppendChild(newBirthday);
                newRecord.AppendChild(recordName);
                newRecord.AppendChild(recordBirthday);
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

        public bool DeleteById(uint id)
        {
            try
            {
                var root = XMLProvider.XmlConnect(path);
                XmlNode xRoot = root.DocumentElement;
                XmlNode node = xRoot.SelectSingleNode(string.Format("user[@id = '{0}']", id));
                XmlNode outer = node.ParentNode;
                outer.RemoveChild(node);
                if (!XMLProvider.XmlSave(root, path)) return false;
                _edited = true;
                return true;
            }
            catch
            {
                return false;
            }

        }

        public IEnumerable<User> GetAll()
        {
            _users.Clear();
            var root = XMLProvider.XmlConnect(path);
            XmlNode xRoot = root.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                User user = new User();
                XmlNode attr = xnode.Attributes.GetNamedItem("id");
                if (attr != null) 
                {
                    uint.TryParse(attr.Value, out uint id);
                    user.Id = id;
                }
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "name")
                        user.Name = childnode.InnerText;

                    if (childnode.Name == "birthday")
                    {
                        DateTime.TryParse(childnode.InnerText, out DateTime birthday);
                        user.DateOfBirth = birthday;
                    }
                        
                }
                _users.Add(user.Id, user);
            }
            _edited = false;
            return _users.Values;
        }

        public User GetById(uint id)
        {
            if (_edited)
            {
                return GetAll().FirstOrDefault(s => s.Id == id);
            }
                return _users.FirstOrDefault(s => s.Key == id).Value;
        }
    }
}
