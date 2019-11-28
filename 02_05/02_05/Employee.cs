using _02_03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _02_05
{
    class Employee : User
    {
        private int _employeeExpirience;
        private string _employeePosition;
        public Employee(string name, string surname, string patronym, DateTime birthdate, string position, int expirience) : base(name, surname, patronym, birthdate)
        {
            UserName = name;
            UserSurname = surname;
            UserPatronymic = patronym;
            UserBirthdate = birthdate;
            EmployeePosition = position;
            EmployeeExpirience = expirience;
        }
        public string EmployeePosition
        {
            get => _employeePosition;
            set
            {
                if (value.Length == 0 || value == null) throw new ArgumentException("Invalid position", nameof(UserPatronymic));
                _employeePosition = value;
            }
        }
        public int EmployeeExpirience
        {
            get => _employeeExpirience;
            set
            {
                if (value<0 || value>UserAge) throw new ArgumentException("Invalid expirience. Must be less than age and bigger than 0", nameof(EmployeeExpirience));
                _employeeExpirience = value;
            }
        }
        public override string ToString()
        {
            return $"Employee: {UserName} {UserPatronymic} {UserSurname}. Birthday = {UserBirthdate.ToString("dd.MM.yy")}. Age = {UserAge}. Expirience = {EmployeeExpirience}";
        }
    }
}
