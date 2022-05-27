using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class RestaurantDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string RestaurantType { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string ZipCode { get; set; }
    }
}
