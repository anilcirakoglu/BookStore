using BookStore.Application.Repositories;
using BookStore.Business;
using Npgsql;
using Quartz;
using System.Xml;
namespace BookStore.Jobs
{
    public class DemoJob : IJob
    {
       

        readonly private IBookBO _bookBO;
        readonly private IPriceBO _priceBO;
        readonly private IUserBO _userBO;
        public DemoJob(IBookBO bookBO,IPriceBO priceBO,IUserBO userBO)
        {

            _bookBO = bookBO;
            _priceBO = priceBO;
            _userBO = userBO;


        }
        public async Task Execute(IJobExecutionContext context)
        {
            
            var books = _bookBO.GetAll().Where(x=>x.published).ToList();
            var prices = _priceBO.GetAll().Where(price => books.Select(book => book.id).Contains(price.bookid)).ToList();

            //var prices = _priceReadRepository.GetAll().Where(price => books.Select(book => book.id).Contains(price.bookid)).ToList().where performasn problemi yaratacağı için kullanılmaması gerekir.

            

            foreach (var price in prices)
            {
                //decimal temp = price.oldprice;

                price.update_Date = DateTime.Now;
                
                if (price.isdiscount )
                {
                    
                    price.price=price.oldprice;
                    //price.oldprice = temp;
                }
                else {

                    
                    decimal discountAmount = price.price * (decimal)(price.discountPercent / 100.0);
                    price.price -= discountAmount;
                   
                }

                price.isdiscount = !price.isdiscount;// tersine çevirmek için 

               await  _priceBO.UpdateAsync(price);
            }


          

            
        }
    }      
}