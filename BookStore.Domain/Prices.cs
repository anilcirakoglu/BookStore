﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain
{
    public class Prices
    {
        public int Id { get; set; }
        public int bookId { get; set; }
        public decimal price { get; set; }

    }
}
