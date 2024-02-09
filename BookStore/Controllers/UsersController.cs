using BookStore.Application.Repositories;
using BookStore.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly private IUsersReadRepository _usersReadRepository;
        public UsersController(IUsersReadRepository usersReadRepository)
        {

            _usersReadRepository = usersReadRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var book = _usersReadRepository.GetAll();
            return Ok(book);
        }

    }
}
