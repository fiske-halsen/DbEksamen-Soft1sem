using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            Seed(builder);
            base.OnModelCreating(builder);
        }
        public static void Seed(ModelBuilder builder)
        {

            builder
  .Entity<Role>()
  .Property(e => e.RoleType)
  .HasConversion(new EnumToStringConverter<Common.Enums.RoleType>());

            builder
  .Entity<Restaurant>()
  .Property(e => e.ResturantType)
  .HasConversion(new EnumToStringConverter<Common.Enums.RestaurantType>());

            builder
  .Entity<MenuItem>()
  .Property(e => e.MenuItemType)
  .HasConversion(new EnumToStringConverter<Common.Enums.MenuItemType>());




            builder.Entity<Role>().HasData(
                new Role { Id = 1, RoleType = Common.Enums.RoleType.Customer },
                new Role { Id = 2, RoleType = Common.Enums.RoleType.Owner }
                );
            builder.Entity<User>().HasData(
                new User { Id = 1, Email = "Niels@Andersen.dk", Name = "Niels", LastName = "Andersen", Password = "1234", PhoneNumber = "44334455", RoleId = 1 },
                new User { Id = 2, Email = "Restaurant@Ejer.dk", Name = "Restaurant", LastName = "Ejer", Password = "1234", PhoneNumber = "44334422", RoleId = 2 },
                new User { Id = 3, Email = "Restaurant@Ejer2.dk", Name = "Restaurant2", LastName = "Ejer2", Password = "1234", PhoneNumber = "44334432", RoleId = 2 }

                );
            builder.Entity<CityInfo>().HasData(
                new CityInfo { Id = 1, City = "Staden", ZipCode = "2500" }

                );
            builder.Entity<Address>().HasData(
                new Address { Id = 1, CityInfoId = 1, StreetName = "PusherStreet" },
                new Address { Id = 2, CityInfoId = 1, StreetName = "NemoLand" }

                );

            builder.Entity<Menu>().HasData(
                new Menu { Id = 1 },
                new Menu { Id = 2 }

                );


            builder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Name = "salatpizza", MenuItemType = Common.Enums.MenuItemType.Food, Price = 79.99, MenuId = 1 },
                new MenuItem { Id = 2, Name = "Peperoni", MenuItemType = Common.Enums.MenuItemType.Food, Price = 79.23, MenuId = 1 },
                new MenuItem { Id = 3, Name = "Calzone", MenuItemType = Common.Enums.MenuItemType.Food, Price = 89.99, MenuId = 1 },
                new MenuItem { Id = 4, Name = "ChokoladeIs", MenuItemType = Common.Enums.MenuItemType.Dessert, Price = 39.99, MenuId = 1 },
                new MenuItem { Id = 5, Name = "vaniljeis", MenuItemType = Common.Enums.MenuItemType.Dessert, Price = 39.99, MenuId = 1 },
                new MenuItem { Id = 6, Name = "chokoladekage", MenuItemType = Common.Enums.MenuItemType.Dessert, Price = 39.99, MenuId = 1 },
                new MenuItem { Id = 7, Name = "Cola", MenuItemType = Common.Enums.MenuItemType.Drink, Price = 19.99, MenuId = 1 },
                new MenuItem { Id = 8, Name = "Fanta", MenuItemType = Common.Enums.MenuItemType.Drink, Price = 19.99, MenuId = 1 },
                new MenuItem { Id = 9, Name = "Mayo", MenuItemType = Common.Enums.MenuItemType.AddOn, Price = 9.99, MenuId = 1 },
                new MenuItem { Id = 10, Name = "Ketchup", MenuItemType = Common.Enums.MenuItemType.AddOn, Price = 9.99, MenuId = 1 },


                new MenuItem { Id = 11, Name = "laks", MenuItemType = Common.Enums.MenuItemType.Food, Price = 79.99, MenuId = 2 },
                new MenuItem { Id = 12, Name = "tun", MenuItemType = Common.Enums.MenuItemType.Food, Price = 79.23, MenuId = 2 },
                new MenuItem { Id = 13, Name = "krabbe", MenuItemType = Common.Enums.MenuItemType.Food, Price = 89.99, MenuId = 2 },
                new MenuItem { Id = 14, Name = "ChokoladeIs", MenuItemType = Common.Enums.MenuItemType.Dessert, Price = 39.99, MenuId = 2 },
                new MenuItem { Id = 15, Name = "vaniljeis", MenuItemType = Common.Enums.MenuItemType.Dessert, Price = 39.99, MenuId = 2 },
                new MenuItem { Id = 16, Name = "chokoladekage", MenuItemType = Common.Enums.MenuItemType.Dessert, Price = 39.99, MenuId = 2 },
                new MenuItem { Id = 17, Name = "Cola", MenuItemType = Common.Enums.MenuItemType.Drink, Price = 19.99, MenuId = 2 },
                new MenuItem { Id = 18, Name = "Fanta", MenuItemType = Common.Enums.MenuItemType.Drink, Price = 19.99, MenuId = 2 },
                new MenuItem { Id = 19, Name = "Mayo", MenuItemType = Common.Enums.MenuItemType.AddOn, Price = 9.99, MenuId = 2 },
                new MenuItem { Id = 20, Name = "Ketchup", MenuItemType = Common.Enums.MenuItemType.AddOn, Price = 9.99, MenuId = 2 }



                );



            builder.Entity<Restaurant>().HasData(
                new Restaurant { AddressId = 1, Id = 1, Name = "PizzaPusheren", ResturantType = Common.Enums.RestaurantType.Pizza, UserId = 2, MenuId = 1 },
                new Restaurant { AddressId = 2, Id = 2, Name = "SushiSlyngeren", ResturantType = Common.Enums.RestaurantType.Sushi, UserId = 3, MenuId = 2 }
                );
        }
    }
}
