using AutoMapper;
using BookStore.Business.Models;
using BookStore.Domain.Entities;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Mapping
{
    public class AutoMapping:Profile
    {
        

        public AutoMapping() {
            CreateMap<BookModel, BookModelDto>();
            CreateMap<PricesModel, PricesModelDto>();
            CreateMap<AuthorsModel,AuthorsModelDto>();
            CreateMap<UsersModel, UsersModelDto>();
            CreateMap<UsersModel, LoginModel>();
        }
    }
}
