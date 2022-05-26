using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class OrderDTO
    {
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string RestaurantType { get; set; }
    }
}
