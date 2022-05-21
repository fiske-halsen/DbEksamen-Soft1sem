using static PostgresAPI.Common.Enums;

namespace PostgresAPI.DTO
{
    public class RestaurantDTO
    {
        public string RestaurantName { get; set; }
        public string RestaurantType { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
