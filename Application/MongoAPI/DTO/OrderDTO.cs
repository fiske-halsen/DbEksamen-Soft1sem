using MongoAPI.DTO;

namespace MongoAPI
{
    public class OrderDTO
    {
        public string RestaurantName { get; set; }
        public List<ItemDTO> Items { get; set; } = new List<ItemDTO>();
        public double TotalPrice { get; set; }
        public string CustomerName { get; set; }
    }
}
