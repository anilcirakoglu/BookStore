using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Models
{
    public class BookWithPropertiesTestModel
    {
        //Soru 12 için hazırlandı.
        //select b.Published, b.name, b.category, b.author , pr.oldprice
        public bool published { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string author { get; set; }
        /// <summary>
        /// Bu alandaki veri oldPrice alanından alınacaktır.
        /// </summary>
        public decimal price { get; set; }
    }
    public class BookWithPropertiesTestModelValidator : FluentValidation.AbstractValidator<BookWithPropertiesTestModel>
    {
        public BookWithPropertiesTestModelValidator()
        {
            
            RuleFor(x => x.name).NotNull();
            RuleFor(x => x.category).NotNull();
            RuleFor(x => x.author).Length(0, 20);
            

        }
    }
}
