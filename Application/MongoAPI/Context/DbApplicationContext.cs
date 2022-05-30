using Common.Models;
using Microsoft.Extensions.Configuration;
using Mongo.Migration.Startup.Static;
using Mongo2Go;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoAPI.Context
{
    public class DbApplicationContext
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
        private readonly IMongoCollection<Order> _ordersCollection;
        private readonly IConfiguration _configuration;

        public DbApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;

            var mongoClient = new MongoClient(_configuration["OrderDatabase:ConnectionString"]);

            var mongoDatabase = mongoClient.GetDatabase(_configuration["OrderDatabase:DatabaseName"]);

            _ordersCollection = mongoDatabase.GetCollection<Order>(_configuration["OrderDatabase:CollectionName"]);
        }

        public void Migration()
        {
            var random = new Random();

            var MenuItems1 = new List<Item>()
            {
                new Item { Name = "salatpizza", Price = 79.99},
                new Item { Name = "Peperoni", Price = 79.23},
                new Item { Name = "Calzone", Price = 89.99},
                new Item { Name = "ChokoladeIs", Price = 39.99 },
                new Item { Name = "vaniljeis", Price = 39.99, },
                new Item { Name = "chokoladekage", Price = 39.99,  },
                new Item { Name = "Cola", Price = 19.99},
                new Item { Name = "Fanta", Price = 19.99, },
                new Item { Name = "Mayo", Price = 9.99, },
                new Item { Name = "Ketchup", Price = 9.99, },
            };

            var MenuItems2 = new List<Item>()
            {
                new Item { Name = "laks", Price = 79.99},
                new Item { Name = "tun", Price = 79.23},
                new Item { Name = "krabbe", Price = 89.99},
                new Item { Name = "ChokoladeIs", Price = 39.99},
                new Item { Name = "vaniljeis",Price = 39.99},
                new Item { Name = "chokoladekage", Price = 39.99},
                new Item { Name = "Cola", Price = 19.99},
                new Item { Name = "Fanta", Price = 19.99},
                new Item { Name = "Mayo", Price = 9.99},
                new Item { Name = "Ketchup", Price = 9.99}
            };

            for (int i = 0; i < 100; i++)
            {
                var menulist = new List<Item>();

                for (int j = 0; j < 5; j++)
                {
                    int index = random.Next(MenuItems1.Count);
                    menulist.Add(MenuItems1[index]);
                }

                _ordersCollection.InsertOneAsync(new Order
                {
                    RestaurantId = 1,
                    RestaurantName = "PizzaPusheren",
                    Items = menulist,
                    CustomerEmail = "Niels@Andersen.dk"
                });
            }

            // Insert old and new version of cars into MongoDB
            var orders = new List<BsonDocument>
            {
                new BsonDocument {
                    {"Restaurant", "Sushi Slyngeren" },
                    {"Items", new BsonArray
                    {
                        new BsonDocument{{"Name", "Cola"}, { "Price", "20.99"} },
                        new BsonDocument{{"Name", "Laks"}, { "Price", "120.99"} },
                        new BsonDocument{{"Name", "Tun"}, { "Price", "95.99"} },
                        new BsonDocument{{"Name", "Eddemamme Bønner"}, { "Price", "51.99"} },
                    } 
                    },
                    {"Restaurant", "Sushi Slyngeren" },
                    {"Items", new BsonArray
                    {
                        new BsonDocument{{"Name", "Fanta"}, { "Price", "22.99"} },
                        new BsonDocument{{"Name", "Krabbe"}, { "Price", "125.99"} },
                        new BsonDocument{{"Name", "Tun"}, { "Price", "87.99"} },
                        new BsonDocument{{"Name", "Spicy Eddemamme Bønner"}, { "Price", "47.99"} },
                    }
                    },
                    {"Restaurant", "Pizza Pusheren" },
                    {"Items", new BsonArray
                    {
                        new BsonDocument{{"Name", "Stor Cola"}, { "Price", "40.99"} },
                        new BsonDocument{{"Name", "Pepperoni"}, { "Price", "75.99"} },
                        new BsonDocument{{"Name", "Kebab"}, { "Price", "85.99"} },
                        new BsonDocument{{"Name", "Ben & Jerry's"}, { "Price", "45.99"} },
                    }
                    },
                    {"Restaurant", "Pizza Pusheren" },
                    {"Items", new BsonArray
                    {
                        new BsonDocument{{"Name", "Fanta"}, { "Price", "20.99"} },
                        new BsonDocument{{"Name", "Mozarella"}, { "Price", "120.99"} },
                        new BsonDocument{{"Name", "Kødsovs"}, { "Price", "95.99"} },
                    }
                    },
                    {"Restaurant", "Pizza Pusheren" },
                    {"Items", new BsonArray
                    {
                        new BsonDocument{{"Name", "Pepsi Max"}, { "Price", "20.99"} },
                        new BsonDocument{{"Name", "Kartoffel"}, { "Price", "120.99"} },
                        new BsonDocument{{"Name", "Skinke"}, { "Price", "95.99"} },
                        new BsonDocument{{"Name", "Vanilje Is"}, { "Price", "51.99"} },
                    }
                    }
                }
            };
        }

    }
}
