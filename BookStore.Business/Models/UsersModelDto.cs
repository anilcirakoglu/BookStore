﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Models
{
    public class UsersModelDto
    {
        public string name { get; set; }
        public string surname { get; set; }
        public double phonenumber { get; set; }
        public string email { get; set; }
    }
}
