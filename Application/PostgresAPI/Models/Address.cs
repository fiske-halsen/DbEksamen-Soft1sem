namespace PostgresAPI.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public CityInfo CityInfo { get; set; }
    }
}