
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Business;
using BookStore.Business.Models;



namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

      
        readonly private IBookBO _bookBO;
       
         


        public BooksController(IBookBO bookBO)
        {
        
            _bookBO = bookBO;
           
        }
        

        [HttpGet]
        public IActionResult GetAll() {
            //var books = _bookReadRepository.GetAll().ToList();
            //var booksWithPrice = new List<BookModel>();
            //var priceList = _priceReadRepository.GetAll().ToList();
            //foreach (var book in books)
            //{
            //    var bookWithPrice = new BookModel
            //    {
            //        id = book.id,
            //        name = book.name,
            //        isbn = book.isbn,
            //        category = book.category,
            //        published = book.published,
            //        author = book.author,
            //        price = priceList.FirstOrDefault(x => x.bookid == book.id).price



            //    };
            //    booksWithPrice.Add(bookWithPrice);
            //}
            
            var books = _bookBO.GetAll();
            return Ok(books);
            
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            //var book= await _bookReadRepository.GetByIdAsync(id);
            //var priceList = _priceReadRepository.GetAll().Where(x=>x.bookid==book.id);
            //var booksWithPrice = new List<BookModel>();
            //var bookWithPrice = new BookModel
            //{
            //    id = book.id,
            //    name = book.name,
            //    isbn = book.isbn,
            //    category = book.category,
            //    published = book.published,
            //    author = book.author,
            //    price = priceList.FirstOrDefault(x => x.bookid == book.id).price



            //};
            //booksWithPrice.Add(bookWithPrice);
            //return Ok(bookWithPrice);
            var books =await _bookBO.GetById(id);
            return Ok(books);

        }
        [HttpPost("create")]
        public async Task<ActionResult<BookModel>> Create(BookModel book)
        {

            //var entity = new Book()
            //{
            //    id = book.id,
            //    name = book.name,
            //    isbn = book.isbn,
            //    category = book.category,
            //    published = book.published,
            //    author = book.author
            //};

            //var entity2 = new Prices()
            //{
            //    id=book.id,
            //    bookid = entity.id,
            //    price = book.price,
            //};



            //await _bookWriteRepository.AddAsync(entity);
            //await _priceWriteRepository.AddAsync(entity2);
            
            //await _bookWriteRepository.SaveAsync();
            //await _priceWriteRepository.SaveAsync();

            //return CreatedAtRoute( new { id = book.id }, book);

            var books =await _bookBO.create(book);
            return Ok(books);
        }
        //[HttpDelete("delete")]


    }
}
