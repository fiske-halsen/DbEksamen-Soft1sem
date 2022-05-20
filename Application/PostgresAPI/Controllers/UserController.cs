using Microsoft.AspNetCore.Mvc;

namespace PostgresAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        //[HttpGet("resturant")]
        //public IEnumerable<WeatherForecast> Get()
        //{
         
        //}
    }
}