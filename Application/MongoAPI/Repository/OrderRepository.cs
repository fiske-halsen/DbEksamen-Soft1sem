using Microsoft.Extensions.Options;
using MongoAPI.Context;
using MongoAPI.Models;
using MongoDB.Driver;

namespace MongoAPI
{
    public class OrderRepository
    {
        private readonly IMongoCollection<Order> _ordersCollection;

        public OrderRepository(
            IOptions<DbApplicationContext> DbApplicationContext)
        {
            var mongoClient = new MongoClient(
                DbApplicationContext.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                DbApplicationContext.Value.MyDatabase);

            _ordersCollection = mongoDatabase.GetCollection<Order>(
                DbApplicationContext.Value.MyCollection);
        }

        public async Task<List<Order>> GetAllOrders() =>
            await _ordersCollection.Find(_ => true).ToListAsync();

        public async Task<Order?> GetOrder(string id) =>
            await _ordersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateOrder(OrderDTO orderDTO)
        {
            var order = new Order
            {

            };

            await _ordersCollection.InsertOneAsync(order);
        }
    }
}
