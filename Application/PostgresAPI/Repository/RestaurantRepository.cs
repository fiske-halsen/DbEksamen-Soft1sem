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
        public Task<IEnumerable<RestaurantDTO>> GetAllRestaurants();
        public Task<RestaurantMenuDTO> GetMenuFromRestaurantId(Restaurant restaurant);
        public Task<MenuItemDTO> UpdateMenuItem(MenuItem menuItem, MenuItemDTO menuItemDTO);
        public Task<MenuItemDTO> CreateMenuItem(MenuItemDTO menuItemDTO, int restaurantId);
        public Task<MenuItemDTO> DeleteMenuItem(MenuItem menuItem);
        public Task<Restaurant> GetRestaurantById(int restaurantId);
        public Task<MenuItem> GetMenuItemFromId(int menuItemId);
    }
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DbApplicationContext _applicationContext;
        private readonly IConfiguration _configuration;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IDatabase _redisDatabase;
        private readonly IServer _redisServer;

        public RestaurantRepository(
            DbApplicationContext applicationContext,
            IRedisCacheService redisCacheService,
            IConfiguration configuration)
        {
            _applicationContext = applicationContext;
            _redisCacheService = redisCacheService;
            _configuration = configuration;
            _redisDatabase = RedisConnector.Connector.Connection.GetDatabase();
            _redisServer = RedisConnector.Connector.Connection.GetServer(_configuration.GetConnectionString("Redis"));
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

            // REDIS CLEAR CACHE SINCE WE ADDED NEW ITEM FOR THAT RESTAURANT
            _redisDatabase.KeyDelete(restaurantId.ToString());

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
        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {
            return await
                _applicationContext.
                Restaurants.
                Select(AsRestaurantDto).
                ToListAsync();
        }
        public async Task<MenuItem> GetMenuItemFromId(int menuItemId)
        {

            var menuItem =
               await _applicationContext.
               MenuItems
             .Include(x => x.MenuItemType).
            FirstOrDefaultAsync(x => x.Id == menuItemId);

            return menuItem;
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
            var redisData = _redisCacheService.Get<string>(restaurant.Id.ToString());

            List<MenuItemDTO> menuItems;
            if (redisData == null)
            {
                menuItems =
                await _applicationContext.
                MenuItems.
                Where(x => x.Menu.Restaurant.Id == restaurant.Id).
                Select(AsMenuItemDto)
               .ToListAsync();

                _redisCacheService.Set<string>(restaurant.Id.ToString(), JsonSerializer.Serialize(menuItems));
            }
            else
            {
                menuItems = JsonSerializer.Deserialize<List<MenuItemDTO>>(redisData);
            }

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
    }
}
