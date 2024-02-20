
using AutoMapper;
using BookStore.Business;
using BookStore.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {


        readonly private IPriceBO _priceBO;
        readonly private IMapper _mapper;

        public PricesController(IPriceBO priceBO,IMapper mapper)
        {
            _priceBO = priceBO;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var price = _priceBO.GetAll();
            var priceDtos = _mapper.Map<List<PricesModelDto>>(price);
            return Ok(priceDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var price = await _priceBO.GetById(id);
            return Ok(price);

        }
        [HttpDelete("delete")]

        public async Task<IActionResult> deleteById(int id)
        {
            await _priceBO.RemoveAsync(id);
            return Ok(id);
        }
       
       
            [HttpPut]

        public IActionResult update(PricesModel priceModel)
        {
            _priceBO.UpdateAsync(priceModel);
            return Ok(priceModel);

        }
    }  
}
