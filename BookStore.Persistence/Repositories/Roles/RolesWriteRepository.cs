using BookStore.Persistence.Context;
using System;
using BookStore.Application.Repositories;
using System.Collections.Generic;
using System.Linq;
using BookStore.Domain.Entities;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Repositories
{
    public class RolesWriteRepository : WriteRepository<Roles>,IRolesWriteRepository
    {
        public RolesWriteRepository(AppDbContext appDbContext) : base(appDbContext) 
        { 
        }
    }
}
