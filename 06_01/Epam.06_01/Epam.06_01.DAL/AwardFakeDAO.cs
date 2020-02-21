using System;
using Epam._06_01.DAO.Interfaces;
using Epam._06_01.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.DAL
{
    public class AwardFakeDAO : IAwardDAO
    {
        private static readonly Dictionary<uint, Award> _awards = new Dictionary<uint, Award>();

        public bool Add(Award award)
        {
            var lastId = _awards.Keys.Count > 0
                ? _awards.Keys.Max()
                : 0;
            award.Id = lastId + 1;
            _awards.Add(award.Id, award);
            return true;
        }
        public Award GetById(uint id)
        {
            _awards.TryGetValue(id, out var award);
            return award;
        }
        public bool DeleteById(uint id)
        {
            try
            {
                _awards.Remove(id);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public IEnumerable<Award> GetAll()
        {
            return _awards.Values;
        }

        public bool EditById(uint id, string newValue)
        {
            try 
            {
                _awards.Values.FirstOrDefault(x => x.Id == id).Name = newValue;
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
