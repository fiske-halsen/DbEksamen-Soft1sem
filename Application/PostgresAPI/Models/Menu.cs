using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresAPI.Models
{
    
    public class Menu
    {
        public int Id { get; set; }
        public ICollection<MenuItem> MenuItem { get; set; }
        
        public Restaurant Restaurant { get; set; }
    }
}