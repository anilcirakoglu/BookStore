using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{
    public class Prices
    {
        public int id{ get; set; }
        public int bookid { get; set; }
        public decimal price { get; set; }
    }
}
