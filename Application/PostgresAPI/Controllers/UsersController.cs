using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostgresAPI.Services;

namespace PostgresAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("/register")]
        public async Task<Response> Register(RegisterUserDTO registerUserDTO)
        {
            return await _userService.Register(registerUserDTO);
        }
    }
}