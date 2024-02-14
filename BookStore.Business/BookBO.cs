using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Application.Repositories;
using BookStore.Business.Models;
using BookStore.Domain.Entities;


namespace BookStore.Business
{
    public class BookBO : IBookBO
    {
        readonly private IBookWriteRepository _bookWriteRepository;
        readonly private IBookReadRepository _bookReadRepository;
        readonly private IPricesReadRepository _priceReadRepository;
        readonly private IPricesWriteRepository _priceWriteRepository;




        public BookBO(IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository, IPricesReadRepository pricesReadRepository, IPricesWriteRepository pricesWriteRepository)
        {

            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
            _priceReadRepository = pricesReadRepository;
            _priceWriteRepository = pricesWriteRepository;




        }

        public async Task<BookModel> create(BookModel bookModel)
        {
            var entity = new Book()
            {
                id = bookModel.id,
                name = bookModel.name,
                isbn = bookModel.isbn,
                category = bookModel.category,
                published = bookModel.published,
                author = bookModel.author
            };

            var entity2 = new Prices()
            {
                id = bookModel.id,
                bookid = entity.id,
                price = bookModel.price,
                oldprice = bookModel.price
            };



            await _bookWriteRepository.AddAsync(entity);
            await _priceWriteRepository.AddAsync(entity2);

            await _bookWriteRepository.SaveAsync();
            await _priceWriteRepository.SaveAsync();
            return bookModel;

        }

        #region methods
        public List<BookModel> GetAll()
        {
            var books = _bookReadRepository.GetAll().ToList();
            var booksWithPrice = new List<BookModel>();
            var priceList = _priceReadRepository.GetAll().ToList();
            foreach (var book in books)
            {
                var bookWithPrice = new BookModel
                {
                    id = book.id,
                    name = book.name,
                    isbn = book.isbn,
                    category = book.category,
                    published = book.published,
                    author = book.author,
                    price = priceList.FirstOrDefault(x => x.bookid == book.id).price,
                    priceTL = AddTLIcon(priceList.FirstOrDefault(x => x.bookid == book.id).price.ToString())



                };
                booksWithPrice.Add(bookWithPrice);
            }
            return booksWithPrice;
        }//ctrl k+d düzeltme

        public async Task<BookModel> GetById(int id, bool tracking = true)
        {
            var book = await _bookReadRepository.GetByIdAsync(id);
            var priceList = _priceReadRepository.GetAll().Where(x => x.bookid == book.id);

            var bookWithPrice = new BookModel
            {
                id = book.id,
                name = book.name,
                isbn = book.isbn,
                category = book.category,
                published = book.published,
                author = book.author,
                price = priceList.FirstOrDefault(x => x.bookid == book.id).price,
                priceTL = priceList.FirstOrDefault(x => x.bookid == book.id).price.ToString() + "TL"



            };

            return bookWithPrice;
        }

        public async Task RemoveAsync(int id)
        {

            var book = await _bookReadRepository.GetByIdAsync(id);
            var bookWithPrice = new BookModel
            {
                id = book.id,
                name = book.name,
                isbn = book.isbn,
                category = book.category,
                published = book.published,
                author = book.author,
                
            }; 
            await _bookWriteRepository.RemoveAsync(id);
            await _bookWriteRepository.SaveAsync();
            


        }

        public async Task<int> SaveAsync()
        {
            var price = await _bookWriteRepository.SaveAsync();
            return price;
        }



        public async Task UpdateAsync(BookModel bookModel)
        {

            var books = _bookReadRepository.GetAll().FirstOrDefault(x => x.id == bookModel.id);
            var prices = _priceReadRepository.GetAll().Where(price => price.bookid == books.id).FirstOrDefault();

            //var prices = _priceReadRepository.GetAll().Where(price => books.Select(book => book.id).Contains(price.bookid)).ToList().where performasn problemi yaratacağı için kullanılmaması gerekir.




            books.name = bookModel.name;
            books.isbn = bookModel.isbn;
            books.category = bookModel.category;
            books.author = bookModel.author;
            books.published = bookModel.published;
            prices.oldprice = bookModel.price;





            _bookWriteRepository.Update(books);
            await _bookWriteRepository.SaveAsync();
        }
        private string AddTLIcon(string prices)
        {

            return prices + " ₺";

        }

        
    }
    #endregion

    


}



