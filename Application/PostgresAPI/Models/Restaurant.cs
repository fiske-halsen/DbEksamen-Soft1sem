using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using static PostgresAPI.Common.Enums;

namespace PostgresAPI.Models
{
    [Index(nameof(AddressId), IsUnique = true)]
    [Index(nameof(MenuId), IsUnique = true)]
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RestaurantType ResturantType { get; set; }
        [ForeignKey("AddressId")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("MenuId")]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
