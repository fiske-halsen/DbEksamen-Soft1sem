using Microsoft.EntityFrameworkCore;
using PostgresAPI.Context;
using PostgresAPI.DTO;
using PostgresAPI.Models;
using System.Linq.Expressions;
using static PostgresAPI.Common.Enums;

namespace PostgresAPI.Repository
{
    public interface IRestaurantRepository
    {
        public Task<IEnumerable<RestaurantDTO>> GetAllRestaurants();
        public Task<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId);

        public Task UpdateMenuItem(int menuItemId, MenuItemDTO menuItemDTO);
        public Task<MenuItemDTO> CreateMenuItem(MenuItemDTO menuItemDTO, int restaurantId);
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
               MenuItemType = x.MenuItemType.MenuItemTypeChoice.ToString(),
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


        /// <summary>
        /// Creates a menu item for a specific restaurantId
        /// </summary>
        /// <param name="menuItemDTO"></param>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public async Task<MenuItemDTO> CreateMenuItem(MenuItemDTO menuItemDTO, int restaurantId)
        {
            var menu = await _applicationContext.Menus.Where(x => x.Restaurant.Id == restaurantId).FirstOrDefaultAsync();
            var menuItemType =
                await _applicationContext.
                MenuItemTypes.Where(x => x.MenuItemTypeChoice == (MenuItemTypeChoice)Enum.Parse(typeof(MenuItemTypeChoice), menuItemDTO.MenuItemType, true)).FirstOrDefaultAsync();

            var menuItem = new MenuItem()
            {
                MenuItemType = menuItemType,
                Price = menuItemDTO.Price,
                Name = menuItemDTO.MenuItemName
            };

            menu.MenuItems.Add(menuItem);
            await _applicationContext.MenuItems.AddAsync(menuItem);

            await _applicationContext.SaveChangesAsync();
            return new MenuItemDTO
            {
                MenuItemName = menuItem.Name,
                MenuItemType = menuItem.MenuItemType.MenuItemTypeChoice.ToString(),
                Price = menuItem.Price
            };
        }

        /// <summary>
        /// Delete menu item from a given menu by menuItemId
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <returns></returns>
        public async Task DeleteMenuItem(int menuItemId)
        {
            var menuItem =
                await _applicationContext.
                MenuItems.
                Where(x => x.Id == menuItemId).
                FirstOrDefaultAsync();

            _applicationContext.MenuItems.Remove(menuItem);

            await _applicationContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all restaurants
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {
            return await
                _applicationContext.
                Restaurants.
                Select(AsRestaurantDto).
                ToListAsync();
        }

        /// <summary>
        /// Gets the restaurant menu by restaurant id
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Updats a given menu item for a specific menu card
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <param name="menuItemDTO"></param>
        /// <returns></returns>
        public async Task UpdateMenuItem(int menuItemId, MenuItemDTO menuItemDTO)
        {
            var menuItem =
               await _applicationContext.
               MenuItems.
               Where(x => x.Id == menuItemId).
               FirstOrDefaultAsync();

            menuItem.Price = menuItemDTO.Price;
            menuItem.Name = menuItemDTO.MenuItemName;
            menuItem.MenuItemType = new MenuItemType() 
            { 
                MenuItemTypeChoice = (MenuItemTypeChoice)Enum.Parse(typeof(MenuItemTypeChoice), menuItemDTO.MenuItemType, true)  
            };

            await _applicationContext.SaveChangesAsync();
        }
    }
}
