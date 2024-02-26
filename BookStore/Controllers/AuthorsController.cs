using AutoMapper;
using BookStore.Business;
using BookStore.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        readonly private IAuthorBO _authorBO;
        readonly private IMapper _mapper;


        public AuthorsController(IAuthorBO authorBO, IMapper mapper)
        {
            _authorBO = authorBO;
            _mapper = mapper;
        }
        #region GetMethod
        [HttpGet]
        public IActionResult Getall()
        {
            var author = _authorBO.GetAll();
            var authorDto = _mapper.Map<List<AuthorsModelDto>>(author);
            return Ok(authorDto);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyID(int id)
        {

            var author = await _authorBO.GetById(id);
            var authorDto = _mapper.Map<AuthorsModelDto>(author);
            return Ok(authorDto);

        }
        #endregion
       
        #region deleteMethod
        [HttpDelete("delete")]
        public async Task<IActionResult> deletebyID(int id)
        {
            await _authorBO.RemoveAsync(id);
            return Ok(id);

        }
        [HttpPut]
        public IActionResult update(AuthorsModel model)
        {
            _authorBO.UpdateAsync(model);
            return Ok(model);
        }

        #endregion



    }
}
