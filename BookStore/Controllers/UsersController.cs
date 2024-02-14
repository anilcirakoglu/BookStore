using BookStore.Business;
using BookStore.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       readonly private IUserBO _userBO;
        public UsersController(IUserBO userBO)
        {
            _userBO = userBO;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var book = _userBO.GetAll();
            return Ok(book);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userBO.GetById(id);
            return Ok(user);

        }
        [HttpPost("create")]
        public async Task<ActionResult<UsersModel>> create(UsersModel usersModel)
        {

            var userCreate =await _userBO.create(usersModel);
            return Ok(userCreate);

        }
        [HttpDelete("delete")]
        public async Task<IActionResult> deleteById(int id)
        {
            await _userBO.RemoveAsync(id);
            return Ok(id);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UsersModel usersModel)
        {


            await _userBO.UpdateAsync(usersModel);
            return Ok(usersModel);

        }

    }
}
