using BookStore.Application.Repositories;
using BookStore.Persistence.Context;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Repositories
{
    public class RolesReadRepository : ReadRepository<Roles>, IRolesReadRepository
    {
        public RolesReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
