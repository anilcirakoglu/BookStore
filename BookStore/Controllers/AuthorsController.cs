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

        [HttpGet]
        public IActionResult Getall() {
            var author =_authorBO.GetAll();
            var authorDto = _mapper.Map<List<AuthorsModelDto>>(author);
            return Ok(authorDto);
        
        }








    }
}
