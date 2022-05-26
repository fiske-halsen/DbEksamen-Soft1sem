using ApiGateway.Service;
using Microsoft.AspNetCore.Mvc;
using Neo4JAPI.DTO;
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

        [HttpGet("/restaurants")]
        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {
            return await _microserviceHandler.GetAllRestaurants();
        }
        [HttpGet("/favorite-food-type")]
        public async Task<FavoriteRestaurantTypeDTO> FindFavoriteRestaurantFromCustomerEmail(string customerEmail)
        {
            return await _microserviceHandler.FindFavoriteRestaurantFromCustomerEmail(customerEmail);
        }
    }
}