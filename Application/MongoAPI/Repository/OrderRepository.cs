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
        public Task<List<Order>> GetAllOrdersFromRestaurant(int restaurantId);
        public Task<List<Order>> GetOrdersFromCustomer(string CustomerEmail);
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
                CustomerName = x.CustomerEmail
            };

        public List<OrderDTO> orderDTOFromCustomer(List<Order> OrdersFromCustomer)
        {
            List<OrderDTO> ordersDTO = new List<OrderDTO>();

            return ordersDTO;
        }

        public async Task<List<Order>> GetAllOrdersFromRestaurant(int restaurantId)
        {
            return await _ordersCollection.Find(x => x.RestaurantId == restaurantId).ToListAsync();

            //return _ordersCollection.AsQueryable().Select(AsOrderDTO).ToList();
        }

        public async Task<List<Order>> GetOrdersFromCustomer(string customerEmail)
        {
            // Return with model Order object
            return await _ordersCollection.Find(x => x.CustomerEmail == customerEmail).ToListAsync();
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await _ordersCollection.InsertOneAsync(order);

            return order;
        }
    }
}
