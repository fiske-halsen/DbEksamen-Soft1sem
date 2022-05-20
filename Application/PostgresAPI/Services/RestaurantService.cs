using PostgresAPI.DTO;
using PostgresAPI.Models;

namespace PostgresAPI.Services
{
    public interface IRestaurantService
    {
        public IEnumerable<Restaurant> GetAllRestaurants();
        public IEnumerable<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId);

        public Task UpdateMenuItem(int menuItemId, MenuItemDTO menuItemDTO);
        public Task CreateMenuItem(MenuItemDTO menuItemDTO, int restaurantId);
        public Task DeleteMenuItem(int menuItemId);
        
    }
    public class RestaurantService : IRestaurantService
    {
        public Task CreateMenuItem(MenuItemDTO menuItemDTO, int restaurantId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMenuItem(int menuItemId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMenuItem(int menuItemId, MenuItemDTO menuItemDTO)
        {
            throw new NotImplementedException();
        }
    }
}
