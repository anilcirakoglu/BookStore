using BookStore.Application.Repositories;
using BookStore.Domain.Entities;
using BookStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Repositories
{
    public class BookReadRepository : ReadRepository<Book>, IBookReadRepository
    {
      
        public BookReadRepository(AppDbContext context) : base(context)
        {
        }

       
    }
}
