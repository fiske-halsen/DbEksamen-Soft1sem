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

        public void Migration(IConfiguration configuration)
        {
            // Init MongoDB
            var runner = MongoDbRunner.Start(); // Mongo2Go
            var client = new MongoClient(runner.ConnectionString);

            // Init MongoMigration
            MongoMigrationClient.Initialize(client);

            client.GetDatabase("MyDatabase").DropCollection("MyCollection");

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

            var bsonCollection =
                client.GetDatabase("MyDatabase").GetCollection<BsonDocument>("MyCollection");

            bsonCollection.InsertManyAsync(orders).Wait();

            Console.WriteLine("Migrate from:");
            orders.ForEach(c => Console.WriteLine(c.ToBsonDocument() + "\n"));
        }

    }
}
