using static PostgresAPI.Common.Enums;

namespace PostgresAPI.Models
{
    public class RestaurantType
    {
        public int Id { get; set; }
        public RestaurantTypeChoice RestaurantTypeChoice { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
