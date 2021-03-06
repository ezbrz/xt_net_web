﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._06_01.Entities
{
    public class AuthUser
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }

    }
}
