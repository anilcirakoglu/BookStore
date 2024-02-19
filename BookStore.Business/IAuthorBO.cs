using BookStore.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business
{
    public interface IAuthorBO
    {
        List<AuthorsModel> GetAll();
        Task<AuthorsModel> GetById(int id, bool tracking = true);
        Task<AuthorsModel> create(AuthorsModel bookModel);

        Task UpdateAsync(AuthorsModel authorModel);
        Task<int> SaveAsync();


        Task RemoveAsync(int id);

    }
}
