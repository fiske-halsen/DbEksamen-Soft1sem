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
        public async Task <RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId)
        {
            return await _microserviceHandler.GetMenuFromRestaurantId(restaurantId);
        }

        [HttpPatch("menu/menu-item/{menuItemId}")]
        public async Task<bool> UpdateMenuItemFromId(int menuItemId, MenuItemDTO menuItemDTO)
        {
            return await _microserviceHandler.UpdateMenuItemFromId(menuItemId, menuItemDTO);
        }

        [HttpPost("{restaurantId}/menu/menu-item")]
        public async Task<bool> AddMenuItem(int restaurantId, MenuItemDTO menuItemDTO)
        {
            return await _microserviceHandler.AddMenuItem(restaurantId, menuItemDTO);
        }

        [HttpDelete("menu/menu-item/{menuItemId}")]
        public async Task<bool> DeleteMenuItemFromId(int menuItemId)
        {
            return await _microserviceHandler.DeleteMenuItemFromID(menuItemId);
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

        // --------------------------------------------- NEO4J ---------------------------------------------
        

        [HttpGet("favorite-restaurant-type/{customerEmail}")]
        public async Task<FavoriteRestaurantTypeDTO> FindFavoriteRestaurantFromCustomerName(string customerEmail)
        {
            return await _microserviceHandler.FindFavoriteRestaurantFromCustomerEmail(customerEmail);
        }

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

        
    }
}