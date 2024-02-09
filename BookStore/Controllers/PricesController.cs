using BookStore.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {

        readonly private IPricesReadRepository _pricesReadRepository;

        public PricesController(IPricesReadRepository pricesReadRepository)
        {

            _pricesReadRepository = pricesReadRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var book = _pricesReadRepository.GetAll();
            return Ok(book);
        }
    }
}
