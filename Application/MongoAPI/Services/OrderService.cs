namespace MongoAPI.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderDTO>> GetAllOrders();
        public Task<OrderDTO> GetOrder(int orderId);
        public Task<OrderDTO> CreateOrder(OrderDTO orderDTO);
    }
    public class OrderService : IOrderService
    {
        private readonly IOrderService _orderService;

        public OrderService(OrderService orderService)
        {
            _orderService = orderService;
        }

        public Task<OrderDTO> CreateOrder(OrderDTO orderDTO)
        {
            return _orderService.CreateOrder(orderDTO);
        }

        public Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            return _orderService.GetAllOrders();
        }

        public Task<OrderDTO> GetOrder(int orderId)
        {
            return _orderService.GetOrder(orderId);
        }
    }
}
