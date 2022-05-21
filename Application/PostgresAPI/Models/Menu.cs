using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresAPI.Models
{
    
    public class Menu
    {
        public int Id { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        
        public Restaurant Restaurant { get; set; }
    }
}