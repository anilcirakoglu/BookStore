using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStore.Domain.Entities;
using System.Threading.Tasks;

namespace BookStore.Application.Repositories.Author
{
    public interface IAuthorReadRepository:IReadRepository<Authors>
    {
    }
}
