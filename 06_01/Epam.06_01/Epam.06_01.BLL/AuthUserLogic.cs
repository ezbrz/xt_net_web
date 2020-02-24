using Epam._06_01.BLL.Interfaces;
using Epam._06_01.DAO.Interfaces;
using Epam._06_01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.BLL
{
    public class AuthUserLogic : IAuthUserLogic
    {
        private readonly IAuthUserDAO _authUserDAO;
        public AuthUserLogic(IAuthUserDAO authUserDAO)
        {
            _authUserDAO = authUserDAO;
        }
        public bool EditById(uint id, string newValue, bool isadmin)
        {
            return _authUserDAO.EditById(id, newValue, isadmin);
        }

        public IEnumerable<AuthUser> GetAll()
        {
            return _authUserDAO.GetAll();
        }

        public AuthUser GetById(uint id)
        {
            return _authUserDAO.GetById(id);
        }

        public AuthUser GetByName(string name)
        {
            return _authUserDAO.GetByName(name);
        }

        public bool Registrate(AuthUser authUser)
        {
            return _authUserDAO.Registrate(authUser);
        }
    }
}
