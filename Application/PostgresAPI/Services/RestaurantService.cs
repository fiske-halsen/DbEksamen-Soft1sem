using PostgresAPI.DTO;
using PostgresAPI.Models;
using PostgresAPI.Repository;

namespace PostgresAPI.Services
{
    public interface IRestaurantService
    {
        public Task<IEnumerable<RestaurantDTO>> GetAllRestaurants();
        public Task<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId);

        public Task UpdateMenuItem(int menuItemId, MenuItemDTO menuItemDTO);
        public Task CreateMenuItem(MenuItemDTO menuItemDTO, int restaurantId);
        public Task DeleteMenuItem(int menuItemId);

    }
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task CreateMenuItem(MenuItemDTO menuItemDTO, int restaurantId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteMenuItem(int menuItemId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {
            return await _restaurantRepository.GetAllRestaurants();
        }

        public async Task<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId)
        {
            return await _restaurantRepository.GetMenuFromRestaurantId(restaurantId);
        }

        public async Task UpdateMenuItem(int menuItemId, MenuItemDTO menuItemDTO)
        {
            throw new NotImplementedException();
        }
    }
}
