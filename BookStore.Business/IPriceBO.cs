using BookStore.Business.Models;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business
{
    public interface IPriceBO
    {
        List<PricesModel> GetAll();
        Task<PricesModel> GetById(int id, bool tracking = true);
        Task<PricesModel> create(PricesModel bookModel);




        Task UpdateAsync(PricesModel priceModel);
        Task<int> SaveAsync();


        Task RemoveAsync(int id);

    }
}
