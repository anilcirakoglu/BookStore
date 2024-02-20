using AutoMapper;
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
        readonly private IMapper _mapper;
        public UsersController(IUserBO userBO,IMapper mapper)
        {
            _userBO = userBO;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var user = _userBO.GetAll();
            var userdto = _mapper.Map<List<UsersModelDto>>(user);
            return Ok(userdto);
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
