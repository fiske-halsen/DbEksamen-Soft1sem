using static PostgresAPI.Common.Enums;

namespace PostgresAPI.DTO
{
    public class MenuItemDTO
    {
        public string MenuItemName { get; set; }

        public double Price { get; set; }

        public MenuItemTypeChoice MenuItemType { get; set;}
    }
}