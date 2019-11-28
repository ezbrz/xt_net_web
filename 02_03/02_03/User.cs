using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_03
{
    public class User
    {
        private string _userName;
        private string _userSurname;
        private string _userPatronymic;
        private DateTime _userBirthdate;

        public string UserName
        {
            get => _userName;
            set
            {
                if (value.Length == 0 || value == null) throw new ArgumentException("Invalid name", nameof(UserName));
                _userName = value;
            }
        }
        public string UserSurname
        {
            get => _userSurname;
            set
            {
                if (value.Length == 0 || value == null) throw new ArgumentException("Invalid surname", nameof(UserSurname));
                _userSurname = value;
            }
        }
        public string UserPatronymic
        {
            get => _userPatronymic;
            set
            {
                if (value.Length == 0 || value == null) throw new ArgumentException("Invalid patronymic", nameof(UserPatronymic));
                _userPatronymic = value;
            }
        }
        public DateTime UserBirthdate
        {
            get => _userBirthdate;
            set
            {
                if (value > DateTime.Today) throw new ArgumentException("Invalid birth date", nameof(UserBirthdate));
                _userBirthdate = value;
            }
        }
        public int UserAge
        {
            get
            {
                int userAge = DateTime.Today.Year - _userBirthdate.Year;
                if (DateTime.Today.AddYears(-userAge) < _userBirthdate) userAge--;
                return userAge;
            }
        }
        public override string ToString()
        {
            return $"User: {UserName} {UserPatronymic} {UserSurname}. Birthday = {UserBirthdate}. Age = {UserAge}";
        }
        public User(string name, string surname, string patronym, DateTime birthdate)
        {
            UserName = name;
            UserSurname = surname;
            UserPatronymic = patronym;
            UserBirthdate = birthdate;
        }
    }
}
