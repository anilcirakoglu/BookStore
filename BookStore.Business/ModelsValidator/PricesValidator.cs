using BookStore.Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.ModelsValidator
{
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
