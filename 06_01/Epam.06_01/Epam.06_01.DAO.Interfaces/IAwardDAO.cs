using Epam._06_01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.DAO.Interfaces
{
    public interface IAwardDAO
    {
        bool Add(Award award);
        Award GetById(uint id);
        bool DeleteById(uint id);
        IEnumerable<Award> GetAll();
    }
}
