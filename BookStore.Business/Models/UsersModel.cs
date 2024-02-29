using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Models
{
    public class UsersModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public double phonenumber { get; set; }
        public string email { get; set; }
        public string? password { get; set; }
        public string username { get; set; }
        
    }
    public class UsersModelValidator : FluentValidation.AbstractValidator<UsersModel>
    {
        public UsersModelValidator()
        {
            RuleFor(x => x.id).NotNull();
            RuleFor(x => x.name).NotNull();
            RuleFor(x => x.surname).NotEmpty();
            RuleFor(x => x.phonenumber).NotNull();
            RuleFor(x => x.email).EmailAddress();
            RuleFor(x=>x.password).NotNull();
            RuleFor(x => x.username).NotNull();



        }
    }
}
