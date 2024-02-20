using BookStore.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Models
{
    public class AuthorsModel
    {
        public int id { get; set; }
        public int tc { get; set; }
        public DateTime birthday {  get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }


    }
    public class AuthorsModelValidator : FluentValidation.AbstractValidator<AuthorsModel>
    {
        public AuthorsModelValidator()
        {
            RuleFor(x => x.id).NotNull();
            RuleFor(x => x.tc).NotNull();
            RuleFor(x => x.birthday).NotNull();
            RuleFor(x => x.name).Length(0, 20);
            RuleFor(x => x.email).EmailAddress();
            RuleFor(x => x.gender).NotNull();

        }
    }

}
