using BookStore.Application.Repositories;
using BookStore.Persistence.Context;
using BookStore.Persistence.Repositories;
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
        public static void AddPersistanceServices(this IServiceCollection services) {

            services.AddDbContext<AppDbContext>(option => option.UseNpgsql("User ID=root;Password=asdqwe1997;Host=localhost;Port=5432;Database=BookStore;"));
            services.AddScoped<IBookReadRepository, BookReadRepository>();
            services.AddScoped<IBookWriteRepository, BookWriteRepository>();

            services.AddScoped<IPricesReadRepository, PricesReadRepository>();
            services.AddScoped<IPricesWriteRepository, PricesWriteRepository>();

            services.AddScoped<IUsersReadRepository, UsersReadRepository>();
            services.AddScoped<IUsersWriteRepository, UsersWriteRepository>();
        } 
    }
}
