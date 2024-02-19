using BookStore.Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.ModelsValidator
{
    public class BooksModelValidator : FluentValidation.AbstractValidator<BookModel>
    {
        public BooksModelValidator()
        {
            RuleFor(x => x.id).NotNull();
            RuleFor(x => x.name).Length(0, 20);
            RuleFor(x => x.isbn).NotNull();
            RuleFor(x => x.category).NotNull();
            RuleFor(x => x.published).NotNull();
            RuleFor(x => x.author).Length(0, 20).NotNull();




        }
    }
}
