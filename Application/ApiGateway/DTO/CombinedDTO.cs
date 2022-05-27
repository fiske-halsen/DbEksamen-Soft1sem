using System.ComponentModel.DataAnnotations;

namespace ApiGateway.DTO
{
    public class CombinedDTO
    {
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string RestaurantType { get; set; }

        public int RestaurantId { get; set; }

        public ICollection<ItemDTO> Items { get; set; } = new List<ItemDTO>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
