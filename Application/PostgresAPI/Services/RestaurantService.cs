using PostgresAPI.DTO;
using PostgresAPI.Models;
using PostgresAPI.Repository;

namespace PostgresAPI.Services
{
    public interface IRestaurantService
    {
        public Task<IEnumerable<RestaurantDTO>> GetAllRestaurants();
        public Task<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId);

        public Task<MenuItemDTO> UpdateMenuItem(int menuItemId, MenuItemDTO menuItemDTO);
        public Task<MenuItemDTO> CreateMenuItem(MenuItemDTO menuItemDTO, int restaurantId);
        public Task<MenuItemDTO> DeleteMenuItem(int menuItemId);

    }
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task <MenuItemDTO> CreateMenuItem(MenuItemDTO menuItemDTO, int restaurantId)
        {
            return await _restaurantRepository.CreateMenuItem(menuItemDTO, restaurantId);
        }

        public async Task <MenuItemDTO> DeleteMenuItem( int menuItemId)
        {
            return await _restaurantRepository.DeleteMenuItem(menuItemId);
        }

        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {
            return await _restaurantRepository.GetAllRestaurants();
        }

        public async Task<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId)
        {
            return await _restaurantRepository.GetMenuFromRestaurantId(restaurantId);
        }

        public async Task <MenuItemDTO> UpdateMenuItem(int menuItemId, MenuItemDTO menuItemDTO)
        {
            throw new NotImplementedException();
        }
    }
}
