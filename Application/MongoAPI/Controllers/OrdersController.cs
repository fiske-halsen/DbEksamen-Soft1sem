using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoAPI.DTO;
using MongoAPI.Models;
using MongoAPI.Services;
using MongoDB.Bson;

namespace MongoAPI.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) =>
            _orderService = orderService;

        [HttpGet("restaurant/{restaurantId}")]
        public async Task<List<Order>> GetAllOrdersFromRestaurant(int restaurantId)
        {
            return await _orderService.GetAllOrdersFromRestaurant(restaurantId);
        }

        [HttpGet("customer/{customerEmail}")]
        public async Task<List<Order>> GetOrdersFromCustomer(string customerEmail)
        {
            return await _orderService.GetOrdersFromCustomer(customerEmail);
        }

        [HttpPost("")]
        public async Task<Order> CreateOrder(Order order)
        {
            return await _orderService.CreateOrder(order);
        }

        [HttpGet("restaurant-summary/{restaurantId}")]
        public List<RestaurantItemsSummaryCount> GetRestaurantSummary(int restaurantId)
        {
            return _orderService.GetRestaurantItemsSummaryCount(restaurantId);
        }
    }
}
