namespace MongoAPI.Services
{
    public interface IOrderService
    {
        public Task<ICollection<OrderDTO>> GetAllOrders();
        public Task<OrderDTO> GetOrder(string orderId);
        public Task<OrderDTO> CreateOrder(OrderDTO orderDTO);
    }
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ICollection<OrderDTO>> GetAllOrders()
        {
            return await _orderRepository.GetAllOrders();
        }

        public async Task<OrderDTO> GetOrder(string orderId)
        {
            return await _orderRepository.GetOrder(orderId);
        }

        public async Task<OrderDTO> CreateOrder(OrderDTO orderDTO)
        {
            return await CreateOrder(orderDTO);
        }
    }
}
