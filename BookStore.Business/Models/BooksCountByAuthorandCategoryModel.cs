using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Models
{
    public class BooksCountByAuthorandCategoryModel
    {
        public int Bookcount { get; set; }
        public string author { get; set; }

        public string category { get; set; }
    }


    public class BooksModelValidator : FluentValidation.AbstractValidator<BooksCountByAuthorandCategoryModel>
    {
        public BooksModelValidator()
        {

            RuleFor(x => x.author).Length(0, 20).NotNull();




        }
    }
}
