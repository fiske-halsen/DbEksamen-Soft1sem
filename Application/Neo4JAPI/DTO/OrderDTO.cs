using System.ComponentModel.DataAnnotations;

namespace Neo4JAPI.DTO
{
    public class OrderDTO
    {
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string RestaurantType { get; set; }
    }
}
