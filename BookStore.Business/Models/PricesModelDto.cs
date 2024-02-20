using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Models
{
    public class PricesModelDto
    {
        public bool isdiscount { get; set; }
        public int price { get; set; }
        public decimal oldprice { get; set; }
        public int discountPercent { get; set; }
    }
}
