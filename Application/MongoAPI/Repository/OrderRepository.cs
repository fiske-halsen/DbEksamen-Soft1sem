using Microsoft.Extensions.Options;
using MongoAPI.Context;
using MongoAPI.DTO;
using MongoAPI.Models;
using MongoDB.Driver;
using System.Linq;
using System.Linq.Expressions;

namespace MongoAPI
{
    public interface IOrderRepository
    {
        public Task<ICollection<OrderDTO>> GetAllOrders();
        public Task<OrderDTO?> GetOrder(string id);
        public Task<OrderDTO> CreateOrder(OrderDTO orderDTO);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _ordersCollection;

        public OrderRepository(
            IOptions<DbApplicationContext> DbApplicationContext)
        {
            var mongoClient = new MongoClient(
                DbApplicationContext.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                DbApplicationContext.Value.DatabaseName);

            _ordersCollection = mongoDatabase.GetCollection<Order>(
                DbApplicationContext.Value.CollectionName);
        }

        private static readonly Expression<Func<Item, ItemDTO>> AsItemDTO =
            x => new ItemDTO()
            {
                Name = x.Name,
                Price = x.Price
            };

        private static readonly Expression<Func<Order, OrderDTO>> AsOrderDTO =
            x => new OrderDTO()
            {
                Id = x.Id,
                RestaurantName = x.RestaurantName,
                Items = (List<ItemDTO>)x.Items,
                Price = x.Price,
                CustomerName = x.CustomerName
            };

        public async Task<ICollection<OrderDTO>> GetAllOrders()
        {
            return (ICollection<OrderDTO>)await _ordersCollection.FindAsync(x => true);
        }

        public async Task<OrderDTO?> GetOrder(string id)
        {
            return (OrderDTO?)await _ordersCollection.FindAsync(x => x.Id == id);
        }

        public async Task<OrderDTO> CreateOrder(OrderDTO orderDTO)
        {
            await _ordersCollection.InsertOneAsync(new Order()
            {
                Id = orderDTO.Id,
                CustomerName = orderDTO.CustomerName,
                Items = (ICollection<Item>)orderDTO.Items,
                Price = orderDTO.Price,
                RestaurantName = orderDTO.RestaurantName
            });

            return orderDTO;
        }
    }
}
