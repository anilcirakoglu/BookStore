using BookStore.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Models
{
    public class AuthorsModel
    {
        public int id { get; set; }
        public int tc { get; set; }
        public DateTime birthday {  get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }


    }
   
}
