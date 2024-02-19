using BookStore.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Entities;
using BookStore.Application.Repositories.Author;

namespace BookStore.Persistence.Repositories.Author
{
    public class AuthorReadRepository:ReadRepository<Authors>,IAuthorReadRepository
    {
        public AuthorReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
