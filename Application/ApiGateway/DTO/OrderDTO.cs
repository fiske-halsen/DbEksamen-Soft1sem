namespace ApiGateway.DTO
{
    public class OrderDTO
    {
        public int RestaurantId { get; set; }

        public string RestaurantName { get; set; }

        public ICollection<ItemDTO> Items { get; set; } = new List<ItemDTO>();

        public string CustomerEmail { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
