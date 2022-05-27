using System.ComponentModel.DataAnnotations;

namespace ApiGateway.DTO
{
    public class RecommendationDTO
    {
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string RestaurantType { get; set; }
    }
}
