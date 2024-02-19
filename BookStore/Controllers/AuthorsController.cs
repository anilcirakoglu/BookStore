using BookStore.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        readonly private IAuthorBO _authorBO;


        public AuthorsController(IAuthorBO authorBO)
        {
            _authorBO = authorBO;
        }









    }
}
