using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Models
{
    public class BookStartingFromId
    {
        public int id { get; set; }
        

        public int take { get; set; }
    }
    public class BookStartingFromIdValidator : FluentValidation.AbstractValidator<BookStartingFromId>
    {
        public BookStartingFromIdValidator()
        {

            RuleFor(x => x.take).NotNull();




        }
    }
}
