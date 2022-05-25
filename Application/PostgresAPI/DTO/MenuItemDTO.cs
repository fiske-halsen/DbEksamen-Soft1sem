using System.ComponentModel.DataAnnotations;

namespace PostgresAPI.DTO
{
    public class MenuItemDTO
    {
        [Required]
        public string MenuItemName { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string MenuItemType { get; set;}
    }
}