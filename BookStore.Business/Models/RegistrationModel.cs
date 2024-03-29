﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Models
{
    public class RegistrationModel
    {
      
        public string username { get; set; }

        public string name { get; set; }
        public string surname { get; set; }
        public double phoneNumber { get; set; }
        public string email { get; set; }

        public string password { get; set; }
    }
}
