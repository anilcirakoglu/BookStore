﻿using BookStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Domain.Entities
{
    public class Users : BaseEntity
    {
        //    public int Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public double phonenumber { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        
    }


}
