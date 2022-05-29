using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostgresAPI.Services;

namespace PostgresAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpGet("")]
        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {
            return await _restaurantService.GetAllRestaurants();
        }
        [HttpGet("{restaurantId}/menu")]
        public async Task<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId)
        {
            return await _restaurantService.GetMenuFromRestaurantId(restaurantId);
        }
        [HttpGet("owner/{ownerId}/menu")]
        public async Task<RestaurantMenuDTO> GetMenuFromOwnerId(int ownerId)
        {
            return await _restaurantService.GetMenuByOwnerId(ownerId);
        }
        [HttpPatch("menu/menu-item/{menuItemId}")]
        public async Task<MenuItemDTO> UpdateMenuItemFromId(int menuItemId, MenuItemDTO menuItemDTO)
        {
            return await _restaurantService.UpdateMenuItem(menuItemId, menuItemDTO);
        }
        [HttpPost("{restaurantId}/menu/menu-item")]
        public async Task<MenuItemDTO> AddMenuItem(int restaurantId, MenuItemDTO menuItemDTO)
        {
            return await _restaurantService.CreateMenuItem(menuItemDTO, restaurantId);
        }
        [HttpDelete("menu/menu-item/{menuItemId}")]
        public async Task <MenuItemDTO> DeleteMenuItemFromId(int menuItemId)
        {
            return await _restaurantService.DeleteMenuItem(menuItemId);
        }
    }
}

