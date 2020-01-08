using Epam._06_01.BLL.Interfaces;
using Epam._06_01.DAL;
using Epam._06_01.DAO.Interfaces;
using Epam._06_01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDAO _userDAO;
        public UserLogic(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }
        public User Add(User user)
        {
            return _userDAO.Add(user);
        }
        public User GetById(uint id)
        {
            return _userDAO.GetById(id);
        }
        public IEnumerable<User> GetAll()
        {
            return _userDAO.GetAll();
        }
    }
}
