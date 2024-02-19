using BookStore.Application.Repositories;
using BookStore.Persistence.Repositories;
using BookStore.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Application.Repositories.Author;
using BookStore.Persistence.Repositories.Author;
using FluentValidation;
using BookStore.Business.Models;
using BookStore.Business.ModelsValidator;

namespace BookStore.Business
{
    public static class ServicesRegistration
    {

        public static void AddPersistanceServices(this IServiceCollection services)
        {
            //services.AddControllers();
            
            services.AddScoped<IBookBO, BookBO>();
            services.AddScoped<IPriceBO, PriceBO>();
            services.AddScoped<IUserBO, UserBO>();
            services.AddScoped<IAuthorBO, AuthorBO>();

            services.AddScoped<IBookReadRepository, BookReadRepository>();
            services.AddScoped<IBookWriteRepository, BookWriteRepository>();

            services.AddScoped<IPricesReadRepository, PricesReadRepository>();
            services.AddScoped<IPricesWriteRepository, PricesWriteRepository>();

            services.AddScoped<IUsersReadRepository, UsersReadRepository>();
            services.AddScoped<IUsersWriteRepository, UsersWriteRepository>();

            services.AddScoped<IAuthorReadRepository, AuthorReadRepository>();
            services.AddScoped<IAuthorWriteRepository, AuthorWriteRepository>();

            services.AddValidatorsFromAssemblyContaining<BooksModelValidator>();
            services.AddValidatorsFromAssemblyContaining<AuthorsModelValidator>();
            services.AddValidatorsFromAssemblyContaining<UsersModelValidator>();
            services.AddValidatorsFromAssemblyContaining<PricesModelValidator>();
        }


    }
}
