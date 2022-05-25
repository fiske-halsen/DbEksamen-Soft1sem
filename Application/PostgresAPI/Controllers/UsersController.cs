using Microsoft.AspNetCore.Mvc;
using PostgresAPI.DTO;
using PostgresAPI.Services;

namespace PostgresAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<Response> Register(RegisterUserDTO registerUserDTO)
        {
           return await _userService.Register(registerUserDTO);
        }
    }
}