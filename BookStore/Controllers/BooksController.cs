using BookStore.Application.Repositories;
using BookStore.Domain.Entities;
using BookStore.Domain.Models;
using BookStore.Persistence.Context;
using BookStore.Persistence.EntityConfigurations;
using BookStore.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        readonly private IBookWriteRepository _bookWriteRepository;
        readonly private IBookReadRepository _bookReadRepository;
        readonly private IPricesReadRepository _priceReadRepository;
         


        public BooksController(IBookReadRepository bookReadRepository,IBookWriteRepository bookWriteRepository,IPricesReadRepository pricesReadRepository)
        {
            
            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
            _priceReadRepository = pricesReadRepository;
         


        }



        //[HttpGet]

        //public  IActionResult GetAll()
        //{
        //    var books = _bookReadRepository.GetAll().ToList();
        //    var booksWithPrice = new List<object>();



        //    foreach (var book in books)
        //    {

        //        var prices = _priceReadRepository.GetAll().Where(p => p.bookid == book.id).Select(p => p.price).ToList();
        //        var bookWithPrice = new
        //        {
        //            book.id,
        //            book.name,
        //            book.isbn,
        //            book.category,
        //            book.published,
        //            book.author,


        //            prices


        //        };
        //        booksWithPrice.Add(bookWithPrice);

        //    }

        //    return Ok(booksWithPrice);
        //}
        [HttpGet]
        public IActionResult GetAll() {
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
                    price = priceList.FirstOrDefault(x => x.bookid == book.id).price



                };
                booksWithPrice.Add(bookWithPrice);
            }
            return Ok(booksWithPrice);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {

            var book= await _bookReadRepository.GetByIdAsync(id);
            var priceList = _priceReadRepository.GetAll().ToList();
            var booksWithPrice = new List<BookModel>();
            var bookWithPrice = new BookModel
            {
                id = book.id,
                name = book.name,
                isbn = book.isbn,
                category = book.category,
                published = book.published,
                author = book.author,
                price = priceList.FirstOrDefault(x => x.bookid == book.id).price



            };
            booksWithPrice.Add(bookWithPrice);
            return Ok(bookWithPrice);
        }
        [HttpPost("create")]
        public async Task<ActionResult<Book>> Create(Book todoItem)
        {
            await _bookWriteRepository.AddAsync(todoItem);
            await _bookWriteRepository.SaveAsync();

            return CreatedAtRoute( new { id = todoItem.id }, todoItem);
        }

    }
}
