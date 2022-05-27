using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MongoAPI.DTO
{
    public class RestaurantItemsSummaryCount
    {
        [BsonElement("count")]
        public int Count { get; set; }
        [BsonElement("itemName")]
        public string ItemName { get; set; }
        [BsonElement("totalPrice")]
        public double totalPrice { get; set; }
    }
}
