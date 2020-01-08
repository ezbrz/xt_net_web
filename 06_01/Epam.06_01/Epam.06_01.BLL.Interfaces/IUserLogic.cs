﻿using Epam._06_01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.BLL.Interfaces
{
    public interface IUserLogic
    {
        User Add(User user);
        User GetById(uint id);
        IEnumerable<User> GetAll();
    }
}
