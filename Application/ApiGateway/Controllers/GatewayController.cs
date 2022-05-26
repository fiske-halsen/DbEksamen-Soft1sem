using ApiGateway.Service;
using Microsoft.AspNetCore.Mvc;
using PostgresAPI.DTO;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        private readonly IMircoserviceHandler _microserviceHandler;

        public GatewayController(IMircoserviceHandler mircoserviceHandler)
        {
            _microserviceHandler = mircoserviceHandler;
        }

        [HttpGet("")]
        public async Task<IEnumerable<RestaurantDTO>> Get()
        {
            return await _microserviceHandler.GetAllRestaurants();
        }
    }
}