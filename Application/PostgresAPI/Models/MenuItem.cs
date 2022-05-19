using static PostgresAPI.Common.Enums;

namespace PostgresAPI.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public MenuItemType MenuItemType { get; set; }
    }
}