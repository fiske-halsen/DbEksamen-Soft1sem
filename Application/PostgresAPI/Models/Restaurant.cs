using static PostgresAPI.Common.Enums;

namespace PostgresAPI.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RestaurantType ResturantType { get; set; }
        public Address Address { get; set; }
        public User User { get; set; }
        public Menu Menu { get; set; }
    }
}
