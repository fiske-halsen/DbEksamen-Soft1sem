﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoAPI.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("RestaurantId")]
        public int RestaurantId { get; set; }

        [BsonElement("RestaurantName")]
        public string RestaurantName { get; set; }

        [BsonElement("Items")]
        public ICollection<Item> Items { get; set; } = new List<Item>();

        [BsonElement("Price")]
        public string Price { get; set; }

        [BsonElement("CustomerEmail")]
        public string CustomerEmail { get; set; }
    }
}
