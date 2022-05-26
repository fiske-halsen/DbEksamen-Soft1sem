using ApiGateway.Models;
using ApiGateway.Service;
using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neo4JAPI.DTO;

namespace ApiGateway.Controllers
{
    [ApiController]
    //[Authorize] TODO: put this on when security is ready....
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        private readonly IMircoserviceHandler _microserviceHandler;

        public GatewayController(IMircoserviceHandler mircoserviceHandler)
        {
            _microserviceHandler = mircoserviceHandler;
        }

        [HttpGet("/restaurants")]
        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {
            return await _microserviceHandler.GetAllRestaurants();
        }

        [HttpPost("/login")]
        public async Task<TokenDTO> Login(LoginUserDTO loginDto)
        {
            return await _microserviceHandler.Login(loginDto);
        }

        //[HttpPost("/register")]
        //public Task<TokenDTO> Register(RegisterUserDTO registerDto)
        //{
        //    return Task.CompletedTask(0);
        //}

        //OPS testing purposes
        // THis one should not be a endpoint but should rather be a combined endpoint
        // with creating a order, and then make logic in microservicehandler for sending data to both mongo and post at the same time
        [HttpGet("/favorite-food-type")]
        public async Task<FavoriteRestaurantTypeDTO> FindFavoriteRestaurantFromCustomerEmail(string customerEmail)
        {
            return await _microserviceHandler.FindFavoriteRestaurantFromCustomerEmail(customerEmail);
        }
    }
}