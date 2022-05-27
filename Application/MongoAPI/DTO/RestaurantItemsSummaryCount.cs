using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MongoAPI.DTO
{
    public class RestaurantItemsSummaryCount
    {
        [BsonElement("Count")]
        public int Count { get; set; }
        [BsonElement("ItemName")]
        public string ItemName { get; set; }
        [BsonElement("TotalPrice")]
        public double TotalPrice { get; set; }
    }
}
