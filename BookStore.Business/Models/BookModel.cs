﻿using BookStore.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Models
{
    public class BookModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string isbn { get; set; }
        public string category { get; set; }
        public bool published { get; set; }
        public string author { get; set; }
        public int author_id { get; set; }
        public decimal price { get; set; }
        public string priceTL { get; set; }
     
    } 
    
        
        
    
}
