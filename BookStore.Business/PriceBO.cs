using BookStore.Application.Repositories;
using BookStore.Business.Models;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business
{
    public class PriceBO: IPriceBO
    {
        readonly private IBookWriteRepository _bookWriteRepository;
        readonly private IBookReadRepository _bookReadRepository;
        readonly private IPricesReadRepository _priceReadRepository;
        readonly private IPricesWriteRepository _priceWriteRepository;




        public PriceBO(IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository, IPricesReadRepository pricesReadRepository, IPricesWriteRepository pricesWriteRepository)
        {

            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
            _priceReadRepository = pricesReadRepository;
            _priceWriteRepository = pricesWriteRepository;




        }

        public Task<PricesModel> create(PricesModel bookModel)
        {
            throw new NotImplementedException();
        }


        public List<PricesModel> GetAll()
        {
            var prices = _priceReadRepository.GetAll().ToList();
            var priceList = new List<PricesModel>();
          
            foreach (var price in prices)
            {
                var PriceWithBookname = new PricesModel()
                {
                    id=price.id,
                    bookid=price.bookid,
                    price=price.price,
                    isdiscount=price.isdiscount,
                    update_Date=price.update_Date,
                    oldprice = price.oldprice,
                    discountPercent =price.discountPercent
                    



                };
                priceList.Add(PriceWithBookname);
            }
            return priceList;
        }

        public async Task<PricesModel> GetById(int id, bool tracking = true)
        {
            var price =await  _priceReadRepository.GetByIdAsync(id);
            

            var Price = new PricesModel
            {
                id = price.id,
                bookid = price.bookid,
                price = price.price,
                isdiscount=price.isdiscount,
                update_Date=price.update_Date,
                oldprice = price.oldprice,
                discountPercent = price.discountPercent



            };

            return Price;
        }

        public async Task RemoveAsync(int id)
        {
            var price = await _priceReadRepository.GetByIdAsync(id);


            var Price = new PricesModel
            {
                id = price.id,
                bookid = price.bookid,
                price = price.price,
                isdiscount = price.isdiscount,
                update_Date = price.update_Date,
                oldprice = price.oldprice,
                discountPercent = price.discountPercent



            };
            await _priceWriteRepository.RemoveAsync(id);
            await _priceWriteRepository.SaveAsync();
        }

        public async Task<int> SaveAsync()
        {
            var price = await _priceWriteRepository.SaveAsync();
            return price;
        }

        
        public async Task UpdateAsync(PricesModel price)
        {
            var updatePrice =_priceReadRepository.GetAll().Where(x=>x.id == price.id && x.bookid==price.bookid).FirstOrDefault();
         
            // if ile price kontrol etmemiz gerekir
            updatePrice.price = price.price;
            updatePrice.isdiscount = price.isdiscount;
            updatePrice.update_Date = price.update_Date;
            updatePrice.oldprice = price.oldprice;
            updatePrice.discountPercent = price.discountPercent;



            
            
           _priceWriteRepository.Update(updatePrice);
            await _priceWriteRepository.SaveAsync();
           
        
        
        }

       
    }
}
