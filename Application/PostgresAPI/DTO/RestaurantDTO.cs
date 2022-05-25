using System.ComponentModel.DataAnnotations;
using static PostgresAPI.Common.Enums;

namespace PostgresAPI.DTO
{
    public class RestaurantDTO
    {
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
