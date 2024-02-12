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
        readonly private IPricesWriteRepository _priceWriteRepository;
       
         


        public BooksController(IBookReadRepository bookReadRepository,IBookWriteRepository bookWriteRepository,IPricesReadRepository pricesReadRepository,IPricesWriteRepository pricesWriteRepository)
        {
            
            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
            _priceReadRepository = pricesReadRepository;
            _priceWriteRepository = pricesWriteRepository;
            
         


        }


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
            var priceList = _priceReadRepository.GetAll().Where(x=>x.bookid==book.id);
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
        public async Task<ActionResult<Book>> Create(BookModel book)
        {

            var entity = new Book()
            {
                id = book.id,
                name = book.name,
                isbn = book.isbn,
                category = book.category,
                published = book.published,
                author = book.author
            };

            var entity2 = new Prices()
            {
                id=book.id,
                bookid = entity.id,
                price = book.price,
            };



            await _bookWriteRepository.AddAsync(entity);
            await _priceWriteRepository.AddAsync(entity2);
            
           await _bookWriteRepository.SaveAsync();
            await _priceWriteRepository.SaveAsync();

            return CreatedAtRoute( new { id = book.id }, book);
        }
        
      
    }
}
