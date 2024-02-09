using BookStore.Application.Repositories;
using BookStore.Domain.Entities;
using BookStore.Persistence.Context;
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
        
        public BooksController(IBookReadRepository bookReadRepository,IBookWriteRepository bookWriteRepository)
        {
            
            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var book = _bookReadRepository.GetAll();
            return Ok(book);
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
