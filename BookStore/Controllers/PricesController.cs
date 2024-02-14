
using BookStore.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {


        readonly private IPriceBO _priceBO;

        public PricesController(IPriceBO priceBO)
        {
            _priceBO = priceBO;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var price = _priceBO.GetAll();
            return Ok(price);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var price = await _priceBO.GetById(id);
            return Ok(price);

        }
        //[HttpDelete("delete")]
    }
}
