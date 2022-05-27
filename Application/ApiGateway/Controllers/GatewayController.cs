using ApiGateway.DTO;
using ApiGateway.Models;
using ApiGateway.Service;
using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        //--------------------------------------------- POSTGRESAPI ---------------------------------------------
        [HttpGet("restaurants")]
        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {
            return await _microserviceHandler.GetAllRestaurants();
        }

        [HttpGet("{restaurantId}/menu-from-restaurant")]
        public async Task <IEnumerable<RestaurantMenuDTO>> GetMenuFromRestaurantId(int restaurantId)
        {
            return await _microserviceHandler.GetMenuFromRestaurantId(restaurantId);
        }

        [HttpPatch("menu/menu-item/{menuItemId}")]
        public async Task<MenuItemDTO> UpdateMenuItemFromId(int menuItemId, MenuItemDTO menuItemDTO)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{restaurantId}/menu/menu-item")]
        public async Task<MenuItemDTO> AddMenuItem(int restaurantId, MenuItemDTO menuItemDTO)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("menu/menu-item/{menuItemId}")]
        public async Task<MenuItemDTO> DeleteMenuItemFromId(int menuItemId)
        {
            throw new NotImplementedException();
        }

        // --------------------------------------------- GATEWAY ---------------------------------------------
        [HttpPost("login")]
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


        // --------------------------------------------- MONGOAPI ---------------------------------------------
        
        [HttpPost("order")]
        public async Task<bool> CreateOrder(CombinedDTO combinedDTO)
        {
            return await _microserviceHandler.CreateOrder(combinedDTO);
        }

        [HttpGet("mongo/restaurant/{restaurantId}")]
        public async Task<IEnumerable<Order>> GetAllOrdersFromRestaurant(int restaurantId)
        {
            return await _microserviceHandler.GetAllOrdersFromRestaurant(restaurantId);
        }

        [HttpGet("mongo/customer/{customerEmail}")]
        public async Task<IEnumerable<Order>> GetOrdersFromCustomer(string customerEmail)
        {
            return await _microserviceHandler.GetOrdersFromCustomer(customerEmail);
        }

        [HttpGet("mongo/restaurant-summary/{restaurantId}")]
        public async Task<IEnumerable<RestaurantItemsSummaryCount>> GetRestaurantSummary(int restaurantId)
        {
            return await _microserviceHandler.GetRestaurantSummary(restaurantId);
        }

        [HttpGet("favorite-food-type")]
        public async Task<FavoriteRestaurantTypeDTO> FindFavoriteRestaurantFromCustomerEmail(string customerEmail)
        {
            return await _microserviceHandler.FindFavoriteRestaurantFromCustomerEmail(customerEmail);
        }
    }
}