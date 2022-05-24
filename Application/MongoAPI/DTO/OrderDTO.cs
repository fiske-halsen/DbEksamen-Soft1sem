using MongoAPI.DTO;

namespace MongoAPI
{
    public class OrderDTO
    {
        public string RestaurantName { get; set; }
        public List<ItemDTO> Items { get; set; } = new List<ItemDTO>();
        public string Price { get; set; }
        public string CustomerName { get; set; }
    }
}
