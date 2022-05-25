using MongoAPI.ErrorHandling;
using MongoAPI.Models;
using MongoDB.Bson;

namespace MongoAPI.Services
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAllOrdersFromRestaurant(int restaurantId);
        public Task<List<Order>> GetOrdersFromCustomer(string CustomerEmail);
        public Task<Order> CreateOrder(Order order);
    }
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetAllOrdersFromRestaurant(int restaurantId)
        {
            var restaurantOrders = await _orderRepository.GetAllOrdersFromRestaurant(restaurantId);
            
            if (restaurantOrders.Count() == 0)
            {
                throw new HttpStatusException(StatusCodes.Status400BadRequest, "No Restaurant with the given ID exists");
            }

            return restaurantOrders;
        }

        public async Task<List<Order>> GetOrdersFromCustomer(string customerEmail)
        {
            var customerOrders = await _orderRepository.GetOrdersFromCustomer(customerEmail);

            if (customerOrders.Count() == 0){
                throw new HttpStatusException(StatusCodes.Status400BadRequest, "No Customer with the given email exists");
            }

            return customerOrders;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            return await _orderRepository.CreateOrder(order);
        }
    }
}
