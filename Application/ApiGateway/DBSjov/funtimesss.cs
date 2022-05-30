using ApiGateway.DTO;
using ApiGateway.Service;
using Common.Models;

namespace ApiGateway.DBSjov
{
    public class funtimesss
    {
        private readonly IMircoserviceHandler _mircoserviceHandler;


        public funtimesss(IMircoserviceHandler mircoserviceHandler)
        {
            _mircoserviceHandler = mircoserviceHandler;
        }

        public void DualMigration()
        {
            var random = new Random();

            var MenuItems1 = new List<ItemDTO>()
            {
                new ItemDTO { Name = "salatpizza", Price = 79.99},
                new ItemDTO { Name = "Peperoni", Price = 79.23},
                new ItemDTO { Name = "Calzone", Price = 89.99},
                new ItemDTO { Name = "ChokoladeIs", Price = 39.99 },
                new ItemDTO { Name = "vaniljeis", Price = 39.99, },
                new ItemDTO { Name = "chokoladekage", Price = 39.99,  },
                new ItemDTO { Name = "Cola", Price = 19.99},
                new ItemDTO { Name = "Fanta", Price = 19.99, },
                new ItemDTO { Name = "Mayo", Price = 9.99, },
                new ItemDTO { Name = "Ketchup", Price = 9.99, },
            };

            var MenuItems2 = new List<ItemDTO>()
            {
                new ItemDTO { Name = "laks", Price = 79.99},
                new ItemDTO { Name = "tun", Price = 79.23},
                new ItemDTO { Name = "krabbe", Price = 89.99},
                new ItemDTO { Name = "ChokoladeIs", Price = 39.99},
                new ItemDTO { Name = "vaniljeis",Price = 39.99},
                new ItemDTO { Name = "chokoladekage", Price = 39.99},
                new ItemDTO { Name = "Cola", Price = 19.99},
                new ItemDTO { Name = "Fanta", Price = 19.99},
                new ItemDTO { Name = "Mayo", Price = 9.99},
                new ItemDTO { Name = "Ketchup", Price = 9.99}
            };

            for (int i = 0; i < 100; i++)
            {
                var menulist = new List<ItemDTO>();

                for (int j = 0; j < 5; j++)
                {
                    int index = random.Next(MenuItems1.Count);
                    menulist.Add(MenuItems1[index]);
                }

                _mircoserviceHandler.CreateOrder(new CombinedDTO
                {
                    RestaurantId = 1,
                    RestaurantName = "PizzaPusheren",
                    RestaurantType = "Pizza",
                    Items = menulist,
                    CustomerEmail = "Niels@Andersen.dk"
                });
            }

            for (int i = 0; i < 100; i++)
            {
                var menulist = new List<ItemDTO>();

                for (int j = 0; j < 5; j++)
                {
                    int index = random.Next(MenuItems2.Count);
                    menulist.Add(MenuItems2[index]);
                }

                _mircoserviceHandler.CreateOrder(new CombinedDTO
                {
                    RestaurantId = 2,
                    RestaurantName = "SushiSlyngeren",
                    RestaurantType = "Sushi",
                    Items = menulist,
                    CustomerEmail = "Niels@Andersen.dk"
                });
            }

        }
        
    }
}
