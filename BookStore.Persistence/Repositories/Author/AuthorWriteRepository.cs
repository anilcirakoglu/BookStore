using BookStore.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStore.Domain.Entities;
using System.Threading.Tasks;
using BookStore.Application.Repositories.Author;

namespace BookStore.Persistence.Repositories.Author
{
    public class AuthorWriteRepository:WriteRepository<Authors>,IAuthorWriteRepository
    {
        public AuthorWriteRepository(AppDbContext context) : base(context)
        {
        }

    }
}
