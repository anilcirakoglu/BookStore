using BookStore.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        

        readonly private IBookReadRepository _bookReadRepository;

        public BooksController(IBookReadRepository bookReadRepository)
        {
            
            _bookReadRepository = bookReadRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _bookReadRepository.GetAll();
            return Ok(books);
        }

    }
}
