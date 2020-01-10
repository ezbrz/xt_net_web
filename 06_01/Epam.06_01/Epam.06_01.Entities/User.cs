using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.Entities
{
    public class User
    {

        private DateTime _dateOfBirth;

        public uint Id { get; set; }
        public string Name { get; set; }
        public List<uint> Awards { get; } = new List<uint>();
        public DateTime DateOfBirth 
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = DateTime.Today >= _dateOfBirth ? value : throw new ArgumentException("Wrong date");
            }
        }
        public int Age
        {
            get
            {
                int _age = DateTime.Today.Year - DateOfBirth.Year;
                if (DateTime.Today.AddYears(-_age) < DateOfBirth) _age--;
                return _age;
            }
        }    
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Birthday: {DateOfBirth.ToShortDateString()}, Age: {Age}";
        }
    }
}
