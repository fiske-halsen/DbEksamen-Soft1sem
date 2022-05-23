using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoAPI.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("RestaurantName")]
        public string RestaurantName { get; set; }

        [BsonElement("Items")]
        public ICollection<Item> Items { get; set; } = new List<Item>();

        [BsonElement("CustomerName")]
        public string CustomerName { get; set; }
    }
}
