using static PostgresAPI.Common.Enums;

namespace PostgresAPI.Models
{
    public class MenuItemType
    {
        public int Id { get; set; }
        public MenuItemTypeChoice MenuItemTypeChoice { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
