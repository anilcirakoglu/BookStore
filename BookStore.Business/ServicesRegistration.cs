using BookStore.Application.Repositories;
using BookStore.Persistence.Repositories;
using BookStore.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business
{
    public static class ServicesRegistration
    {

        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddScoped<IBookBO, BookBO>();
            services.AddScoped<IPriceBO, PriceBO>();
            services.AddScoped<IUserBO, UserBO>();

            services.AddScoped<IBookReadRepository, BookReadRepository>();
            services.AddScoped<IBookWriteRepository, BookWriteRepository>();

            services.AddScoped<IPricesReadRepository, PricesReadRepository>();
            services.AddScoped<IPricesWriteRepository, PricesWriteRepository>();

            services.AddScoped<IUsersReadRepository, UsersReadRepository>();
            services.AddScoped<IUsersWriteRepository, UsersWriteRepository>();


        }


    }
}
