using FluentValidation;
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
    public class PricesModelValidator : FluentValidation.AbstractValidator<PricesModel>
    {
        public PricesModelValidator()
        {
            RuleFor(x => x.id).NotNull();
            RuleFor(x => x.bookid).NotNull();
            RuleFor(x => x.price).NotEmpty();
            RuleFor(x => x.oldprice).NotEmpty();
            RuleFor(x => x.isdiscount).NotNull();
            RuleFor(x => x.discountPercent).NotNull();




        }
    }
}
