namespace Common.Models
{
    public class RestaurantMenuDTO
    {
        public string RestaurantName { get; set; }
        public List<MenuItemDTO> Menu { get; set; } = new List<MenuItemDTO>();
    }
}
