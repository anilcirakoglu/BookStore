
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
        
            
            var books = _bookBO.GetAll();
            return Ok(books);
            
        }

        [HttpGet("GetBookWithProperties")]
        public IActionResult GetBookWithProperties()
        {


            var books = _bookBO.GetBookWithProperties();
            return Ok(books);

        }

        [HttpGet("GetBookCountsInCategory")]
        public IActionResult GetBookCountsInCategory()
        {

            //select count("category"),category from "Books" group by category
            var books = _bookBO.GetBookCountsInCategory();
            return Ok(books);

        }
        

        [HttpGet("category/{category}/author/{author}")]
        public IActionResult getfindBooksByCategoryAndAuthor(string category,string author)
        {


            var books = _bookBO.getFindBooksByCategoryAndAuthor(category, author);
            return Ok(books);

        }
        [HttpGet("id/{id}/take/{take}")]
        public IActionResult getbooksStartingFromId(int id, int take)
        {


            var books = _bookBO.getBooksStartingFromId(id, take);
            return Ok(books);

        }
        [HttpGet("allBooks count by author")]
        public IActionResult getCountBooksByAuthor(int id, int take)
        {


            var books = _bookBO.getBooksStartingFromId(id, take);
            return Ok(books);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var books =await _bookBO.GetById(id);
            return Ok(books);

        }
        [HttpPost("create")]
        public async Task<ActionResult<BookModel>> Create(BookModel book)
        {


            var books =await _bookBO.create(book);
            return Ok(books);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> deleteById(int id) {
            await _bookBO.RemoveAsync(id);
            return Ok(id);
        }



        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(BookModel bookModel)
        {
            await _bookBO.UpdateAsync(bookModel);
            return Ok(bookModel);
        }


    }
}
