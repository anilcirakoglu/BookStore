using BookStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Repositories
{
    public interface IWriteRepository<T>: IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model);//birden fazla eklemek için

        bool Remove(T model);
        bool RemoveRange(List<T> model);
        Task< bool> RemoveAsync(int id);
        bool UpdateAsync(T model);

        Task<int> SaveAsync();
        /*bool eklendiyse t/f döndürmek için*/
    }
}
