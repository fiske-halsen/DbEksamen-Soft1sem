using Common.ErrorHandling;
using PostgresAPI.DTO;
using PostgresAPI.Models;
using PostgresAPI.Repository;
using RestaurantMicroservice.ErrorHandling;

namespace PostgresAPI.Services
{
    public interface IRestaurantService
    {
        public Task<IEnumerable<RestaurantDTO>> GetAllRestaurants();
        public Task<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId);

        public Task<MenuItemDTO> UpdateMenuItem(int menuItemId, MenuItemDTO menuItemDTO);
        public Task<MenuItemDTO> CreateMenuItem(MenuItemDTO menuItemDTO, int restaurantId);
        public Task<MenuItemDTO> DeleteMenuItem(int menuItemId);
        public Task<Response> Register(RegisterUserDTO registerUserDTO);

    }
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IUserRepository _userRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository, IUserRepository userRepository)
        {
            _restaurantRepository = restaurantRepository;
            _userRepository = userRepository;
        }

        public async Task<MenuItemDTO> CreateMenuItem(MenuItemDTO menuItemDTO, int restaurantId)
        {
            return await _restaurantRepository.CreateMenuItem(menuItemDTO, restaurantId);
        }

        public async Task<MenuItemDTO> DeleteMenuItem(int menuItemId)
        {
            var menuItem = await _restaurantRepository.GetMenuItemFromId(menuItemId);
            if (menuItem == null)
            {
                throw new HttpStatusException(StatusCodes.Status400BadRequest, "No menu item with the given id");
            }
            return await _restaurantRepository.DeleteMenuItem(menuItem);
        }
        public async Task<MenuItemDTO> UpdateMenuItem(int menuItemId, MenuItemDTO menuItemDTO)
        {
            var menuItem = await _restaurantRepository.GetMenuItemFromId(menuItemId);
            if (menuItem == null)
            {
                throw new HttpStatusException(StatusCodes.Status400BadRequest, "No Menu Item With Given ID");
            }

            return await _restaurantRepository.UpdateMenuItem(menuItem, menuItemDTO);
        }

        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {
            return await _restaurantRepository.GetAllRestaurants();
        }

        public async Task<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId)
        {
            var restaurant = await _restaurantRepository.GetRestaurantById(restaurantId);
            if (restaurant == null)
            {
                throw new HttpStatusException(StatusCodes.Status400BadRequest, "No Restaurant With Given ID");
            }
            return await _restaurantRepository.GetMenuFromRestaurantId(restaurant);
        }

        public async Task<Response> Register(RegisterUserDTO registerUserDTO)
        {
            var password = registerUserDTO.Password;
            var confirmPassword = registerUserDTO.PasswordRepeated;

            //var user = await _userRepository.GetUserByEmail(registerUserDTO.Email);

            //if (user != null)
            //{
            //    throw new HttpStatusException(StatusCodes.Status400BadRequest, "User with the given email already exists");
            //}

            //if (!password.Equals(confirmPassword))
            //{
            //    throw new HttpStatusException(StatusCodes.Status400BadRequest, "Passwords not matching..");
            //}

            return await _userRepository.Register(registerUserDTO);
        }
    }
}
