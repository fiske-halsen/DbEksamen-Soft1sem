
namespace Common.Models
{
    public class Order
    {
        public int RestaurantId { get; set; }

        public string RestaurantName { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();

        public double TotalPrice { get; set; }

        public string CustomerEmail { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
