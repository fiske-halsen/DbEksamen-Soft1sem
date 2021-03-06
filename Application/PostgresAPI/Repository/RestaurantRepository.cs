using Common.Models;
using Microsoft.EntityFrameworkCore;
using PostgresAPI.Common;
using PostgresAPI.Context;
using PostgresAPI.Models;
using StackExchange.Redis;
using System.Linq.Expressions;
using System.Text.Json;
using static PostgresAPI.Common.Enums;

namespace PostgresAPI.Repository
{
    public interface IRestaurantRepository
    {
        public Task<List<RestaurantDTO>> GetAllRestaurants();
        public Task<RestaurantMenuDTO> GetMenuFromRestaurantId(Restaurant restaurant);
        public Task<MenuItemDTO> UpdateMenuItem(MenuItem menuItem, MenuItemDTO menuItemDTO);
        public Task<MenuItemDTO> CreateMenuItem(MenuItemDTO menuItemDTO, int restaurantId);
        public Task<MenuItemDTO> DeleteMenuItem(MenuItem menuItem);
        public Task<Restaurant> GetRestaurantById(int restaurantId);
        public Task<MenuItem> GetMenuItemFromId(int menuItemId);
        public Task<RestaurantMenuDTO> GetMenuByOwnerId(User user); 

    }
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DbApplicationContext _applicationContext;
        private readonly IConfiguration _configuration;

        public RestaurantRepository( DbApplicationContext applicationContext)
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
            Id = x.Id,
            RestaurantName = x.Name,
            RestaurantType = x.ResturantType.RestaurantTypeChoice.ToString(),
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
        public async Task<MenuItemDTO> DeleteMenuItem(MenuItem menuItem)
        {
            MenuItemDTO tmpMenuItem = new MenuItemDTO
            {
                MenuItemName = menuItem.Name,
                MenuItemType = menuItem.MenuItemType.MenuItemTypeChoice.ToString(),
                Price = menuItem.Price
            };
            _applicationContext.MenuItems.Remove(menuItem);

            await _applicationContext.SaveChangesAsync();

            return tmpMenuItem;
        }

        /// <summary>
        /// Get all restaurants
        /// </summary>
        /// <returns></returns>
        public async Task<List<RestaurantDTO>> GetAllRestaurants()
        {
            return await
            _applicationContext.
            Restaurants.
            Select(AsRestaurantDto).
            ToListAsync();
        }

        public async Task<MenuItem> GetMenuItemFromId(int menuItemId)
        {
            return await _applicationContext.
                    MenuItems
                    .Include(x => x.MenuItemType).
                    FirstOrDefaultAsync(x => x.Id == menuItemId);
        }

        public async Task<Restaurant> GetRestaurantById(int restaurantId)
        {
            var resturant =
                await _applicationContext.
                Restaurants.
                Where(x => x.Id == restaurantId).
                FirstOrDefaultAsync();

            return resturant;
        }
        /// <summary>
        /// Gets the restaurant menu by restaurant id
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public async Task<RestaurantMenuDTO> GetMenuFromRestaurantId(Restaurant restaurant)
        {
            var menuItems =
             await _applicationContext.
             MenuItems.
             Where(x => x.Menu.Restaurant.Id == restaurant.Id).
             Select(AsMenuItemDto)
            .ToListAsync();

            return new RestaurantMenuDTO()
            {
                RestaurantName = restaurant.Name,
                Menu = menuItems
            };
        }

        /// <summary>
        /// Updats a given menu item for a specific menu card
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <param name="menuItemDTO"></param>
        /// <returns></returns>
        public async Task<MenuItemDTO> UpdateMenuItem(MenuItem menuItem, MenuItemDTO menuItemDTO)
        {
            menuItem.Price = menuItemDTO.Price;
            menuItem.Name = menuItemDTO.MenuItemName;
            menuItem.MenuItemType = menuItem.MenuItemType;

            await _applicationContext.SaveChangesAsync();
            return new MenuItemDTO
            {
                MenuItemName = menuItem.Name,
                MenuItemType = menuItem.MenuItemType.MenuItemTypeChoice.ToString(),
                Price = menuItem.Price
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<RestaurantMenuDTO> GetMenuByOwnerId(User user)
        {
            var menuItems =
               await _applicationContext.MenuItems
               .Include(x => x.Menu)
               .Include(x => x.Menu.Restaurant)
               .Include(x => x.Menu.Restaurant.User)
               .Where(x => x.Menu.Restaurant.User.Id == user.Id)
               .Select(AsMenuItemDto)
               .ToListAsync();

            return new RestaurantMenuDTO()
            {
                Menu = menuItems
            };
        }
    }
}
