using Epam._06_01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.BLL.Interfaces
{
    public interface IUserLogic
    {
        bool Add(User user);
        User GetById(uint id);
        bool DeleteById(uint id);
        IEnumerable<User> GetAll();
        List<uint> GetUserAwards(uint id);
        bool GrantUserAwards(uint idUser, uint idAward);
        bool DeleteAward(uint idUser, uint idAward);
        bool EditUser(uint idUser, string newValue, DateTime newBirthday, List<uint> newAwards);
    }
}
