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
    public class AwardLogic : IAwardLogic
    {
        private readonly IAwardDAO _awardDAO;
        public AwardLogic(IAwardDAO userDAO)
        {
            _awardDAO = userDAO;
        }
        public bool Add(Award award)
        {
            return _awardDAO.Add(award);
        }
        public Award GetById(uint id)
        {
            return _awardDAO.GetById(id);
        }
        public bool DeleteById(uint id)
        {
            return _awardDAO.DeleteById(id);
        }
        public IEnumerable<Award> GetAll()
        {
            return _awardDAO.GetAll();
        }
    }
}
