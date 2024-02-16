using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
            //var a = _bookReadRepository.GetAll().Where(x => x.isbn == bookModel.isbn).FirstOrDefault();
            //bookModel.id = a.id;
            //var a = _auread.getwithunique( getall.where yap içinde)
            // return etmeden önce auModel.id değerini a.id den alıp set et ve auModeli return et

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

        public List<BookModel> getBooksStartingFromId(int id, int take)
        {
            var books = _bookReadRepository.GetAll().Where(x => x.id >= id).OrderBy(x => x.id).Take(take).ToList();
            var BooksStartingFromId = new List<BookModel>();
            var priceList = _priceReadRepository.GetAll().Where(b => b.id >= id).ToList();
            foreach (var book in books)
            {
                var bookStartingFromId = new BookModel
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
                BooksStartingFromId.Add(bookStartingFromId);


            }// (sayfa-1)*pagesize skip değeri --- take> pagesize
            return BooksStartingFromId;
        }
        public List<BookModel> getFindBooksByCategoryAndAuthor(string category, string author)
        {
            var books = _bookReadRepository.GetAll().Where(x => x.category == category && x.author == author);
            var priceList = _priceReadRepository.GetAll().ToList();
            var booksWithCategoryAndAuthor = new List<BookModel>();
            foreach (var book in books)
            {
                var bookWithCategoryAndAuthor = new BookModel
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
                booksWithCategoryAndAuthor.Add(bookWithCategoryAndAuthor);


            }
            return booksWithCategoryAndAuthor;
        }



        //public List<BookModel> getCountBooksByAuthor()
        //{
        //    //select count("name"),author from "Books" group by author
        // var book =_bookReadRepository.GetAll().;
        //  var booksWithAuthor = new List<BookModel>();




        //}


        #endregion
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

        public List<BookModel> getCountBooksByAuthor()
        {
            throw new NotImplementedException();
        }

        public List<BookWithPropertiesTestModel> GetBookWithProperties()
        {
            //select b.Published, b.name, b.category, b.author , pr.oldprice from "Books" b
            //inner join "Prices" pr on b.id = pr.bookid
            var books = _bookReadRepository.GetAll();
            var prices = _priceReadRepository.GetAll();

            var joinedList = books.Join(prices,
                            book => book.id,
                            price => price.bookid,
                            (book, price) => new BookWithPropertiesTestModel 
                            {
                                published = book.published,
                                name = book.name,
                                category = book.category,
                                author = book.author,
                                price = price.oldprice
                            }).ToList();


            //lambda expression
            //var joinedList = books.Join(prices,
            //                book => book.Id,
            //                price => price.BookId,
            //                (book, price) => new { Book = book, Price = price });


            //linq expression
            var joinedList2 = (from book in books
                             join price in prices on book.id equals price.bookid
                             select new BookWithPropertiesTestModel
                             {
                                published =book.published,
                                name = book.name,
                                category = book.category,
                                author = book.author,
                                price = price.oldprice
                             }).ToList();

            //return joinedList;
            return joinedList2; // her iki kullanım da mümkün
        }

        public List<BookCountsInCategoryModel> GetBookCountsInCategory()
        {
            var books = _bookReadRepository.GetAll();
            var a = books.GroupBy(book => book.category).Select(row => new BookCountsInCategoryModel
            {
                Category = row.Key,
                BookCount = row.Count()
            }).ToList();


            var b = (from book in books
                     group book by book.category into row
                     select new BookCountsInCategoryModel
                     {
                         Category = row.Key,
                         BookCount = row.Count()
                     }).ToList();

            return a;
            //return b;
        }
    }





}



