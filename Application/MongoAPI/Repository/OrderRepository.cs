using Microsoft.Extensions.Options;
using MongoAPI.Context;
using MongoAPI.DTO;
using MongoAPI.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Linq.Expressions;

namespace MongoAPI
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOrderRepository
    {
        public Task<List<Order>> GetAllOrdersFromRestaurant(int restaurantId);
        public Task<List<Order>> GetOrdersFromCustomer(string CustomerEmail);
        public Task<Order>  CreateOrder (Order order);
        public List<RestaurantItemsSummaryCount> GetRestaurantItemsSummaryCount(int restaurantId);
    }

    /// <summary>
    /// 
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _ordersCollection;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DbApplicationContext"></param>
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
        /// <summary>
        /// 
        /// </summary>
        private static readonly Expression<Func<Item, ItemDTO>> AsItemDTO =
            x => new ItemDTO()
            {
                Name = x.Name,
                Price = x.Price
            };
        /// <summary>
        /// 
        /// </summary>
        private static readonly Expression<Func<Order, OrderDTO>> AsOrderDTO =
            x => new OrderDTO()
            {
                RestaurantName = x.RestaurantName,
                Items = (List<ItemDTO>)x.Items,
                TotalPrice = x.TotalPrice,
                CustomerName = x.CustomerEmail
            };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public async Task<List<Order>> GetAllOrdersFromRestaurant(int restaurantId)
        {
            return await _ordersCollection.Find(x => x.RestaurantId == restaurantId).ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerEmail"></param>
        /// <returns></returns>
        public async Task<List<Order>> GetOrdersFromCustomer(string customerEmail)
        {
            // Return with model Order object
            return await _ordersCollection.Find(x => x.CustomerEmail == customerEmail).ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<Order> CreateOrder(Order order)
        {
            await _ordersCollection.InsertOneAsync(order);

            return order;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public List<RestaurantItemsSummaryCount> GetRestaurantItemsSummaryCount(int restaurantId)
        {
            string map = "function(){"
                   + "var order = this;" +
                  "if (order.RestaurantId == " + restaurantId +
                  "){"
                +
                " for (var i = 0; i < order.Items.length; i++) {" +
                               " var key = order.Items[i].Name;" +
                               " emit(key, { Count: 1, TotalPrice: order.Items[i].Price }); } } }";

            string reduce = @"function(key, values) {
                            var result = { ItemName: 0, Count: 0, TotalPrice: 0 };
                            values.forEach(function(value){               
                                result.Count += value.Count;
                                result.TotalPrice += value.TotalPrice;
                                result.ItemName = key;
                            });
                            return result;
                        }";

            //var builder = Builders<Order>.Filter;

            var options = new MapReduceOptions<Order, BsonDocument>();
            options.OutputOptions = MapReduceOutputOptions.Inline;

            var results = _ordersCollection.MapReduce(map, reduce, options);

            var list = results.ToList().OrderByDescending(x => x[1]);

            var summaryList = list.Select(e => BsonSerializer.Deserialize<RestaurantItemsSummaryCount>(JObject.Parse(e.ToJson())["value"].ToString())).ToList();

            return summaryList;
        }
    }
}
