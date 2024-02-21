using AutoMapper;
using BookStore.Business;
using BookStore.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    { 
       readonly  private ILogger<UsersController> _logger;
        readonly private IUserBO _userBO;
        readonly private IMapper _mapper;
        readonly private IMemoryCache _cache;
       
        
      
        
        public UsersController(IUserBO userBO, IMapper mapper,IMemoryCache memoryCache,ILogger<UsersController> logger)
        {
            _userBO = userBO;
            _mapper = mapper;
            _cache = memoryCache;
            _logger = logger;
            
           
           
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var cacheKey = "Users"; // Önbellek anahtarı

            
            if (_cache.TryGetValue(cacheKey, out var cachedData))
            {
                var usersDto = cachedData as List<UsersModelDto>;
                return Ok(usersDto);
            }
            else
            {
               
                var users = _userBO.GetAll();
                var usersDto = _mapper.Map<List<UsersModelDto>>(users);

                
                _cache.Set(cacheKey, usersDto, new MemoryCacheEntryOptions
                {
                    // Önbellekten otomatik olarak kaldırılma süresi
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                });

                return Ok(usersDto);
            }
            //var user = _userBO.GetAll();
            //var userdto = _mapper.Map<List<UsersModelDto>>(user);
            //return Ok(userdto);
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


            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Information("New user creating: {@User}", usersModel);
            Log.Information("HTTP Response: {@Response}", usersModel);


            var userCreate = await _userBO.create(usersModel);
            

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
