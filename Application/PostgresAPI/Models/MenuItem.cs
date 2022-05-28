using System.ComponentModel.DataAnnotations.Schema;
using static PostgresAPI.Common.Enums;

namespace PostgresAPI.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        [ForeignKey("MenuItemTypeId")]
        public int MenuItemTypeId { get; set; }
        public MenuItemType MenuItemType { get; set; }
        [ForeignKey("MenuId")]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}