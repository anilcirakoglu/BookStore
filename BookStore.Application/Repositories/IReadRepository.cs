using BookStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T:BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T,bool>> method, bool tracking = true);//Verilen şart ifadesi doğru olanları sorgulanıp getirileceği.
        Task<T> GetSingleAsync(Expression<Func<T,bool>> method, bool tracking = true);//şarta uygun olan ilkini getirir
        Task<T> GetByIdAsync(int id, bool tracking = true);
    }
}
