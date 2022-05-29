using Common.ErrorHandling;
using Common.Models;
using PostgresAPI.Models;
using PostgresAPI.Repository;
using RestaurantMicroservice.ErrorHandling;
using StackExchange.Redis;
using System.Text.Json;

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
        public Task<RestaurantMenuDTO> GetMenuByOwnerId(int ownerId);
    }

    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IDatabase _redisDatabase;
        private readonly IServer _redisServer;
        private readonly IConfiguration _configuration;


        public RestaurantService(
            IRestaurantRepository restaurantRepository,
            IUserRepository userRepository,
            IRedisCacheService redisCacheService,
            IConfiguration configuration)
        {
            _restaurantRepository = restaurantRepository;
            _userRepository = userRepository;
            _redisCacheService = redisCacheService;
            _configuration = configuration;
            _redisDatabase = RedisConnector.Connector.Connection.GetDatabase();
            _redisServer = RedisConnector.Connector.Connection.GetServer(_configuration.GetConnectionString("Redis"));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuItemDTO"></param>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public async Task<MenuItemDTO> CreateMenuItem(MenuItemDTO menuItemDTO, int restaurantId)
        {
            var menuItems =  await _restaurantRepository.CreateMenuItem(menuItemDTO, restaurantId);
            // REDIS CLEAR CACHE SINCE WE ADDED NEW ITEM FOR THAT RESTAURANT
            _redisDatabase.KeyDelete(restaurantId.ToString());
            return menuItems;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <returns></returns>
        /// <exception cref="HttpStatusException"></exception>
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {
            var restaurantRedisKey = "AllRestaurants";
            var redisCache = _redisCacheService.Get<string>(restaurantRedisKey);

            var restaurants = new List<RestaurantDTO>();

            if (redisCache == null)
            {
                restaurants = await _restaurantRepository.GetAllRestaurants();

                _redisCacheService.Set<string>(restaurantRedisKey, JsonSerializer.Serialize(restaurants));
            }
            else
            {
                restaurants = JsonSerializer.Deserialize<List<RestaurantDTO>>(redisCache);
            }
            return restaurants;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        /// <exception cref="HttpStatusException"></exception>
        public async Task<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId)
        {
            var restaurant = await _restaurantRepository.GetRestaurantById(restaurantId);
            if (restaurant == null)
            {
                throw new HttpStatusException(StatusCodes.Status400BadRequest, "No Restaurant With Given ID");
            }

            var redisData = _redisCacheService.Get<string>(restaurant.Id.ToString());

            RestaurantMenuDTO restaurantMenuDTO;

            if (redisData == null)
            {
                restaurantMenuDTO = await _restaurantRepository.GetMenuFromRestaurantId(restaurant);

                _redisCacheService.Set<string>(restaurant.Id.ToString(), JsonSerializer.Serialize(restaurantMenuDTO));
            }
            else
            {
                restaurantMenuDTO = JsonSerializer.Deserialize<RestaurantMenuDTO>(redisData);
            }

            return restaurantMenuDTO;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerUserDTO"></param>
        /// <returns></returns>
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

        public async Task<RestaurantMenuDTO> GetMenuByOwnerId(int ownerId)
        {
           var user = await _userRepository.GetUserById(ownerId); 

            if (user == null)
            {
                throw new HttpStatusException(StatusCodes.Status404NotFound, "User does not exist");
            }

            return await _restaurantRepository.GetMenuByOwnerId(user);
        }
    }
}
