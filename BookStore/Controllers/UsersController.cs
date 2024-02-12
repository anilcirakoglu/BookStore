using BookStore.Application.Repositories;
using BookStore.Domain.Entities;
using BookStore.Domain.Models;
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
        readonly private IUsersWriteRepository _usersWriteRepository;
        public UsersController(IUsersReadRepository usersReadRepository, IUsersWriteRepository usersWriteRepository)
        {

            _usersReadRepository = usersReadRepository;
            _usersWriteRepository = usersWriteRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var book = _usersReadRepository.GetAll();
            return Ok(book);
        }
        [HttpPost("create")]
        public async Task<ActionResult<Users>> createUser(UsersModel usersModel)
        {


            var entity = new Users()
            {

                id = usersModel.id,
                name = usersModel.name,
                surname = usersModel.surname,
                phonenumber = usersModel.phonenumber,
                email = usersModel.email
            };
            await _usersWriteRepository.AddAsync(entity);
            await _usersWriteRepository.SaveAsync();
            return CreatedAtRoute(new { id = usersModel.id }, usersModel);

        }

    }
}
