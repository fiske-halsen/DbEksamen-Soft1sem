using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoAPI.Models
{
    public class Item
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        [BsonElement("Price")]
        public string Price { get; set; }

    }
}
