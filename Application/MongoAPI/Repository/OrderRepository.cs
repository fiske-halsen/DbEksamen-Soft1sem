using Microsoft.Extensions.Options;
using MongoAPI.Context;
using MongoAPI.DTO;
using MongoAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using System.Linq.Expressions;

namespace MongoAPI
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetAllOrders();
        public Task<OrderDTO?> GetOrder(ObjectId id);
        public Task<Order> CreateOrder(Order order);
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
                RestaurantName = x.RestaurantName,
                Items = (List<ItemDTO>)x.Items,
                Price = x.Price,
                CustomerName = x.CustomerName
            };

        public async Task<OrderDTO?> GetOrder(ObjectId id)
        {
            return (OrderDTO?)await _ordersCollection.FindAsync(x => x.Id == id);
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await _ordersCollection.InsertOneAsync(order);

            return order;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _ordersCollection.Find(x => true).ToListAsync();

            //return _ordersCollection.AsQueryable().Select(AsOrderDTO).ToList();
        }
    }
}
