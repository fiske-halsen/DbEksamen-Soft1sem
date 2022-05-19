using Microsoft.EntityFrameworkCore;
using PostgresAPI.Models;

namespace PostgresAPI.Context
{
    public class DbApplicationContext : DbContext
    {
        public DbApplicationContext(DbContextOptions<DbApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CityInfo> CityInfos { get; set; }
    }
}
