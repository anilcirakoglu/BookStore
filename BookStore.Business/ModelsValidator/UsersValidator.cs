using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.Models;
using FluentValidation;

namespace BookStore.Business.ModelsValidator
{
    public class UsersModelValidator : FluentValidation.AbstractValidator<UsersModel>
    {
        public UsersModelValidator()
        {
            RuleFor(x => x.id).NotNull();
            RuleFor(x => x.name).NotNull();
            RuleFor(x => x.surname).NotEmpty();
            RuleFor(x => x.phonenumber).NotNull();
            RuleFor(x => x.email).EmailAddress();





        }
    }
}
