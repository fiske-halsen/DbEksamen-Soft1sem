using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoAPI.Models;
using MongoAPI.Services;
using MongoDB.Bson;

namespace MongoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) =>
            _orderService = orderService;

        [HttpGet("")]
        public async Task<List<Order>> GetAllOrders()
        {
            return await _orderService.GetAllOrders();
        }

        [HttpGet("order/{orderId}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(ObjectId id)
        {
            return await _orderService.GetOrder(id);
        }

        [HttpPost("")]
        public async Task<Order> CreateOrder(Order order)
        {
            return await _orderService.CreateOrder(order);
        }
    }
}
