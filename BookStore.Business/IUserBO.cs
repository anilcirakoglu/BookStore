using BookStore.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business
{
    public interface IUserBO
    {
        List<UsersModel> GetAll();
        Task<UsersModel> GetById(int id, bool tracking = true);
        Task<UsersModel> create(UsersModel userModel);
        Task UpdateAsync(UsersModel userModel);
        Task<int> SaveAsync();

        Task RemoveAsync(int id);
    }
}
