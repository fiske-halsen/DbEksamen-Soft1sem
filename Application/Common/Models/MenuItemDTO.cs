using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class MenuItemDTO
    {
        [Required]
        public string MenuItemName { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string MenuItemType { get; set; }
    }
}
