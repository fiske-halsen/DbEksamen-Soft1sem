using System.ComponentModel.DataAnnotations.Schema;
using static PostgresAPI.Common.Enums;

namespace PostgresAPI.Models
{
    public class Role
    {
        public int Id { get; set; }
        public RoleType RoleType { get; set; }
        public ICollection<User> User { get; set; }
    }
}
