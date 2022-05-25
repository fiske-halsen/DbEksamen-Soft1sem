﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostgresAPI.DTO;
using PostgresAPI.Models;
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
        [HttpGet("/{restaurantId}/menu")]
        public async Task<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId)
        {
            return await _restaurantService.GetMenuFromRestaurantId(restaurantId);
        }
        [HttpPatch("/menu/menu-item/{menuItemId}")]
        public async Task<MenuItemDTO> UpdateMenuItemFromId(int menuItemId, MenuItemDTO menuItemDTO)
        {
            return await _restaurantService.UpdateMenuItem(menuItemId, menuItemDTO);
        }
        [HttpPost("/{restaurantId}/menu/menu-item")]
        public async Task<MenuItemDTO> AddMenuItem(int restaurantId, MenuItemDTO menuItemDTO)
        {
            return await _restaurantService.CreateMenuItem(menuItemDTO, restaurantId);
        }
        [HttpDelete("/menu/menu-item/{menuItemId}")]
        public async Task <MenuItemDTO> DeleteMenuItemFromId(int menuItemId)
        {
            return await _restaurantService.DeleteMenuItem(menuItemId);
        }

        [AllowAnonymous]
        [HttpPost("/register")]
        public async Task<Response> Register(RegisterUserDTO registerUserDTO)
        {
            return await _restaurantService.Register(registerUserDTO);

            //return new Response()
            //{
            //    Message = "sads",
            //    Status = "success"
            //};
        }

    }

}
