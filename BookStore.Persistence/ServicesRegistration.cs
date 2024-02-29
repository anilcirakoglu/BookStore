using BookStore.Application.Repositories;
using BookStore.Application.Repositories.Author;
using BookStore.Domain.Entities;
using BookStore.Persistence.Context;
using BookStore.Persistence.Repositories;
using BookStore.Persistence.Repositories.Author;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence
{
    public static class ServicesRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {


            services.AddScoped<IBookReadRepository, BookReadRepository>();
            services.AddScoped<IBookWriteRepository, BookWriteRepository>();
            
            services.AddScoped<IPricesReadRepository, PricesReadRepository>();
            services.AddScoped<IPricesWriteRepository, PricesWriteRepository>();
            
            services.AddScoped<IUsersReadRepository, UsersReadRepository>();
            services.AddScoped<IUsersWriteRepository, UsersWriteRepository>();
            
            services.AddScoped<IAuthorReadRepository,AuthorReadRepository>();
            services.AddScoped<IAuthorWriteRepository,AuthorWriteRepository>();

            services.AddScoped<IRolesReadRepository, RolesReadRepository>();
            services.AddScoped<IRolesWriteRepository, RolesWriteRepository>();

            services.AddScoped<ICustomerRoleReadRepository, CustomerRoleReadRepository>();
            services.AddScoped<ICustomerRoleWriteRepository, CustomerRoleWriteRepository>();


        }
    }
}
