using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_01
{
    class People
    {
        private string _name;
        private string _surName;

        public string Name
        {
            get => _name;
            set
            {
                if (value.Length > 0) { _name = value; } else { throw new ArgumentException("Invalid first name", "name"); }
            }
        }
        public string Surname
        {
            get => _surName;
            set
            {
                if (value.Length > 0) { _surName = value; } else { throw new ArgumentException("Invalid first name", "name"); }
            }
        }

        public People(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string PeopleCharacteristic
        {
            get => $"{this.Name} {this.Surname}";
        }
    }
}
