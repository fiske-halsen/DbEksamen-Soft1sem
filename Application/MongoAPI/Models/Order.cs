using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoAPI.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        //TODO FIX to upper case R
        [BsonElement("restaurantId")]
        public int RestaurantId { get; set; }

        [BsonElement("RestaurantName")]
        public string RestaurantName { get; set; }

        [BsonElement("Items")]
        public ICollection<Item> Items { get; set; } = new List<Item>();

        [BsonElement("TotalPrice")]
        public double TotalPrice { get; set; }

        [BsonElement("CustomerEmail")]
        public string CustomerEmail { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
