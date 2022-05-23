namespace MongoAPI.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderDTO>> GetAllOrders();
        public Task<OrderDTO> GetOrder(int orderId);
        public Task<OrderDTO> CreateOrder(OrderDTO orderDTO);
    }
    public class OrderService
    {
    }
}
