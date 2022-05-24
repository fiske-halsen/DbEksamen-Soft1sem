using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoAPI.Models;
using MongoAPI.Services;

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
        public async Task<ICollection<OrderDTO>> GetAllOrders()
        {
            return await _orderService.GetAllOrders();
        }

        [HttpGet("order/{orderId}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(string id)
        {
            return await _orderService.GetOrder(id);
        }

        [HttpPost("")]
        public async Task<OrderDTO> CreateOrder(OrderDTO orderDTO)
        {
            return await _orderService.CreateOrder(orderDTO);
        }
    }
}
