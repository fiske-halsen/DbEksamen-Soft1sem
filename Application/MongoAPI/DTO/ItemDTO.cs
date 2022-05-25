using MongoDB.Bson.Serialization.Attributes;

namespace MongoAPI.DTO
{
    public class ItemDTO
    {
        public string Name { get; set; }

        public double Price { get; set; }
    }
}
