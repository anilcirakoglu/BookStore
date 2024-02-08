using BookStore.Application.Repositories;
using BookStore.Domain.Entities;
using BookStore.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Repositories
{
    public class UsersWriteRepository : WriteRepository<Users>, IUsersWriteRepository
    {
        public UsersWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
