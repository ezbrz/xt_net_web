using Epam._06_01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.DAO.Interfaces
{
    public interface IAuthUserDAO
    {
        IEnumerable<AuthUser> GetAll();
        AuthUser GetById(uint id);
        AuthUser GetByName(string name);
        bool EditById(uint id, string newValue, bool isadmin);
        bool Registrate(AuthUser authUser);
    }
}
