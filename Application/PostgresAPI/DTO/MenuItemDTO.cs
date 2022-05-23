using static PostgresAPI.Common.Enums;

namespace PostgresAPI.DTO
{
    public class MenuItemDTO
    {
        public string MenuItemName { get; set; }

        public double Price { get; set; }

        public string MenuItemType { get; set;}
    }
}