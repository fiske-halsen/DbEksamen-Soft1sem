using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostgresAPI.DTO;
using PostgresAPI.Models;
using PostgresAPI.Services;

namespace PostgresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet("")]
        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {
            return await _restaurantService.GetAllRestaurants();
        }

        [HttpGet("/{restaurantId}/menu")]
        public async Task<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId)
        {
            return await _restaurantService.GetMenuFromRestaurantId(restaurantId);
        }

        ////TODO: only correct owner
        //[HttpPatch("/menu/{int:menuItemId}")]
        //public IEnumerable<dynamic> UpdateMenuItemFromId(int menuItemId)
        //{
        //    return 1;
        //}
        //[HttpPost("/menu")]
        //public IEnumerable<dynamic> AddMenuItem()
        //{
        //    return 1;
        //}
        //[HttpDelete("/menu/{int:menuItemId}")]
        //public IEnumerable<dynamic> DeleteMenuItemFromId(int menuItemId)
        //{
        //    return 1;
        //}

    }
}
