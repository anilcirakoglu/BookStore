using BookStore.Application.Repositories;
using BookStore.Domain.Entities;
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

        

        [HttpGet]
        //public IActionResult GetAll()
        //{
        //    //var book = _bookReadRepository.GetAll();
        //    //return Ok(book);


        //}
        public  IActionResult GetAll()
        {
            var books = _bookReadRepository.GetAll();
            var booksWithPrice = new List<object>();
            var price = _priceReadRepository.GetAll();
            
            foreach (var book in books)
            {
                

                var bookWithPrice = new
                {
                    book.id,
                    book.name,
                    book.isbn,
                    book.category,
                    book.published,
                    book.author,
                   


                    Price = price 
                };
                booksWithPrice.Add(bookWithPrice);
             
            }
            return Ok(booksWithPrice);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {

            var book= await _bookReadRepository.GetByIdAsync(id);
            return Ok(book);
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
