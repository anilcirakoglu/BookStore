using BookStore.Application.Repositories;
using BookStore.Domain.Models;
using Npgsql;
using Quartz;
using System.Xml;
namespace BookStore.Jobs
{
    public class DemoJob : IJob
    {
        readonly private IBookWriteRepository _bookWriteRepository;
        readonly private IBookReadRepository _bookReadRepository;
        readonly private IPricesReadRepository _priceReadRepository;
        readonly private IPricesWriteRepository _priceWriteRepository;
        public DemoJob(IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository, IPricesReadRepository pricesReadRepository, IPricesWriteRepository pricesWriteRepository)
        {

            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
            _priceReadRepository = pricesReadRepository;
            _priceWriteRepository = pricesWriteRepository;




        }
        public async Task Execute(IJobExecutionContext context)
        {
            
            var books = _bookReadRepository.GetAll().Where(x=>x.published).ToList();
            var prices = _priceReadRepository.GetAll().Where(price => books.Select(book => book.id).Contains(price.bookid)).ToList();
            //var prices = _priceReadRepository.GetAll().Where(price => books.Select(book => book.id).Contains(price.bookid)).ToList().where performasn problemi yaratacağı için kullanılmaması gerekir.
           


            foreach (var price in prices)
            {
               
                 price.update_Date = DateTime.Now;
                if (price.isdiscount )
                {
                    price.price = price.oldprice;
                }
                else {
                    Random rnd = new Random();
                    int discountPercent = rnd.Next(10, 51);

                    decimal discountAmount = price.price * (decimal)(discountPercent / 100.0);
                    price.price -= discountAmount;
                }

                price.isdiscount = !price.isdiscount;// tersine çevirmek için 
                 _priceWriteRepository.UpdateAsync(price);
            }

            
            await _priceWriteRepository.SaveAsync();

            
        }
    }      
}