using Microsoft.EntityFrameworkCore;
using PostgresAPI.Context;
using PostgresAPI.DTO;
using PostgresAPI.Models;
using System.Linq.Expressions;

namespace PostgresAPI.Repository
{
    public interface IRestaurantRepository
    {
        public Task<IEnumerable<RestaurantDTO>> GetAllRestaurants();
        public Task<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId);

        public Task UpdateMenuItem(int menuItemId, MenuItemDTO menuItemDTO);
        public Task CreateMenuItem(MenuItemDTO menuItemDTO, int restaurantId);
        public Task DeleteMenuItem(int menuItemId);
    }

    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DbApplicationContext _applicationContext;
        public RestaurantRepository(DbApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        private static readonly Expression<Func<MenuItem, MenuItemDTO>> AsMenuItemDto =
           x => new MenuItemDTO()
           {
               MenuItemName = x.Name,
               MenuItemType = x.MenuItemType.MenuItemTypeChoice,
               Price = x.Price
           };

        private static readonly Expression<Func<Restaurant, RestaurantDTO>> AsRestaurantDto =
        x => new RestaurantDTO()
        {
          RestaurantName = x.Name,
          RestaurantType = x.ResturantType.RestaurantTypeChoice,
          StreetName = x.Address.StreetName,
          City = x.Address.CityInfo.City,
          ZipCode = x.Address.CityInfo.ZipCode
        };


        public Task CreateMenuItem(MenuItemDTO menuItemDTO, int restaurantId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMenuItem(int menuItemId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {
            return await _applicationContext.Restaurants.Select(AsRestaurantDto).ToListAsync();
        }

        public async Task<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId)
        {
            var resturant =
                await _applicationContext.
                Restaurants.
                Where(x => x.Id == restaurantId).
                FirstOrDefaultAsync();

            var menuItems =
                await _applicationContext.
                MenuItems.
                Where(x => x.Menu.Restaurant.Id == restaurantId).
                Select(AsMenuItemDto)
               .ToListAsync();

            return new RestaurantMenuDTO()
            {
                RestaurantName = resturant.Name,
                Menu = menuItems
            };
        }

        public Task UpdateMenuItem(int menuItemId, MenuItemDTO menuItemDTO)
        {
            throw new NotImplementedException();
        }
    }
}
