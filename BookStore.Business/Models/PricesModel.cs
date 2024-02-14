using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Models
{
    public class PricesModel
    {
        public int id{ get; set; }
        public int bookid { get; set; }
        public decimal price { get; set; }
        public DateTime update_Date { get; set; }
        public bool isdiscount { get; set; }
        public decimal oldprice { get; set; }
        public int discountPercent{ get; set; }
    }
}
