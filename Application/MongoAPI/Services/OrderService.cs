using MongoAPI.Models;
using MongoDB.Bson;

namespace MongoAPI.Services
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAllOrders();
        public Task<OrderDTO> GetOrder(ObjectId orderId);
        public Task<Order> CreateOrder(Order order);
    }
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _orderRepository.GetAllOrders();
        }

        public async Task<OrderDTO> GetOrder(ObjectId orderId)
        {
            return await _orderRepository.GetOrder(orderId);
        }

        public async Task<Order> CreateOrder(Order order)
        {
            return await _orderRepository.CreateOrder(order);
        }
    }
}
