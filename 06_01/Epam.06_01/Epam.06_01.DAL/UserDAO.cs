using Epam._06_01.DAO.Interfaces;
using Epam._06_01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.DAL
{
    public class UserDAO : IUserDAO
    {
        private static readonly Dictionary<uint, User> _users = new Dictionary<uint, User>();

        public User Add(User user)
        {
            var lastId = _users.Keys.Count > 0
                ? _users.Keys.Max()
                : 0;
            user.Id = lastId + 1;
            _users.Add(user.Id, user);
            return user;
        }
        public User GetById(uint id)
        {
            _users.TryGetValue(id, out var user);
            return user;
        }
        public IEnumerable<User> GetAll()
        {
            return _users.Values;
        }
    }
}
