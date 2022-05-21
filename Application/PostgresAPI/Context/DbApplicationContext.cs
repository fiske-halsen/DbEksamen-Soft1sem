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

        public DbSet<MenuItemType> MenuItemTypes { get; set; }

        public DbSet<RestaurantType> RestaurantTypes { get; set; }


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
           .Entity<RestaurantType>()
           .Property(e => e.RestaurantTypeChoice)
           .HasConversion(new EnumToStringConverter<Common.Enums.RestaurantTypeChoice>());

            builder
           .Entity<MenuItemType>()
           .Property(e => e.MenuItemTypeChoice)
           .HasConversion(new EnumToStringConverter<Common.Enums.MenuItemTypeChoice>());



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
            builder.Entity<MenuItemType>().HasData(
             new MenuItemType { Id = 1, MenuItemTypeChoice = Common.Enums.MenuItemTypeChoice.AddOn },
             new MenuItemType { Id = 2, MenuItemTypeChoice = Common.Enums.MenuItemTypeChoice.Dessert },
             new MenuItemType { Id = 3, MenuItemTypeChoice = Common.Enums.MenuItemTypeChoice.Food },
             new MenuItemType { Id = 4, MenuItemTypeChoice = Common.Enums.MenuItemTypeChoice.Drink }
             );


            builder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Name = "salatpizza", MenuItemTypeId = 3, Price = 79.99, MenuId = 1 },
                new MenuItem { Id = 2, Name = "Peperoni", MenuItemTypeId = 3, Price = 79.23, MenuId = 1 },
                new MenuItem { Id = 3, Name = "Calzone", MenuItemTypeId = 3, Price = 89.99, MenuId = 1 },
                new MenuItem { Id = 4, Name = "ChokoladeIs", MenuItemTypeId = 2, Price = 39.99, MenuId = 1 },
                new MenuItem { Id = 5, Name = "vaniljeis", MenuItemTypeId = 2, Price = 39.99, MenuId = 1 },
                new MenuItem { Id = 6, Name = "chokoladekage", MenuItemTypeId = 2, Price = 39.99, MenuId = 1 },
                new MenuItem { Id = 7, Name = "Cola", MenuItemTypeId = 4, Price = 19.99, MenuId = 1 },
                new MenuItem { Id = 8, Name = "Fanta", MenuItemTypeId = 4, Price = 19.99, MenuId = 1 },
                new MenuItem { Id = 9, Name = "Mayo", MenuItemTypeId = 1, Price = 9.99, MenuId = 1 },
                new MenuItem { Id = 10, Name = "Ketchup", MenuItemTypeId = 1, Price = 9.99, MenuId = 1 },


                new MenuItem { Id = 11, Name = "laks", MenuItemTypeId = 3, Price = 79.99, MenuId = 2 },
                new MenuItem { Id = 12, Name = "tun", MenuItemTypeId = 3, Price = 79.23, MenuId = 2 },
                new MenuItem { Id = 13, Name = "krabbe", MenuItemTypeId = 3, Price = 89.99, MenuId = 2 },
                new MenuItem { Id = 14, Name = "ChokoladeIs", MenuItemTypeId = 2, Price = 39.99, MenuId = 2 },
                new MenuItem { Id = 15, Name = "vaniljeis", MenuItemTypeId = 2, Price = 39.99, MenuId = 2 },
                new MenuItem { Id = 16, Name = "chokoladekage", MenuItemTypeId = 2, Price = 39.99, MenuId = 2 },
                new MenuItem { Id = 17, Name = "Cola", MenuItemTypeId = 4, Price = 19.99, MenuId = 2 },
                new MenuItem { Id = 18, Name = "Fanta", MenuItemTypeId = 4, Price = 19.99, MenuId = 2 },
                new MenuItem { Id = 19, Name = "Mayo", MenuItemTypeId = 1, Price = 9.99, MenuId = 2 },
                new MenuItem { Id = 20, Name = "Ketchup", MenuItemTypeId = 1, Price = 9.99, MenuId = 2 }
                );

            builder.Entity<RestaurantType>().HasData(
              new RestaurantType { Id = 1, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Salat },
              new RestaurantType { Id = 2, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Cafe },
              new RestaurantType { Id = 3, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Vietnamese },
              new RestaurantType { Id = 4, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Vegan },
              new RestaurantType { Id = 5, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Mexican },
              new RestaurantType { Id = 6, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Bagel },
              new RestaurantType { Id = 7, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Bar },
              new RestaurantType { Id = 8, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Burger },
              new RestaurantType { Id = 9, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Chinese },
              new RestaurantType { Id = 10, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Danish },
              new RestaurantType { Id = 11, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Dessert },
              new RestaurantType { Id = 12, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Icecream },
              new RestaurantType { Id = 13, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Indian },
              new RestaurantType { Id = 14, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Italian },
              new RestaurantType { Id = 15, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Pizza },
              new RestaurantType { Id = 16, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Sushi },
              new RestaurantType { Id = 17, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Sandwich },
              new RestaurantType { Id = 18, RestaurantTypeChoice = Common.Enums.RestaurantTypeChoice.Thai }
              );



            builder.Entity<Restaurant>().HasData(
                new Restaurant { AddressId = 1, Id = 1, Name = "PizzaPusheren", ResturantTypeId = 15, UserId = 2, MenuId = 1 },
                new Restaurant { AddressId = 2, Id = 2, Name = "SushiSlyngeren", ResturantTypeId = 16, UserId = 3, MenuId = 2 }
            );
        }
    }
}
