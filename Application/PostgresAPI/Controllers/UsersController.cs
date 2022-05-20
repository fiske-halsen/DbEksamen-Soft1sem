using Microsoft.AspNetCore.Mvc;

namespace PostgresAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        //[HttpPost("login")]
        //public IEnumerable<dynamic> Login()
        //{
        //    return 1;
        //}


        //[HttpPost("register")]
        //public IEnumerable<dynamic> Register()
        //{
        //    return 1;
        //}

    }
}