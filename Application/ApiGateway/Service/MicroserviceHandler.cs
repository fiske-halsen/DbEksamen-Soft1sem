using ApiGateway.DTO;
using ApiGateway.Models;
using Common.Models;
using System.Security.Claims;
using System.Text.Json;

namespace ApiGateway.Service
{
    public interface IMircoserviceHandler
    {
        public Task<IEnumerable<RestaurantDTO>> GetAllRestaurants();
        public Task<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId);
        public Task<FavoriteRestaurantTypeDTO> FindFavoriteRestaurantFromCustomerEmail(string customerEmail);
        
        public Task<TokenDTO> Login(LoginUserDTO loginDto);
        public Task<bool> Register(RegisterUserDTO registerDto);
        public Task<bool> CreateOrder(CombinedDTO combinedDTO);
        public Task<IEnumerable<Order>> GetAllOrdersFromRestaurant(int restaurantId);
        public Task<IEnumerable<Order>> GetOrdersFromCustomer(string customerEmail);
        public Task<IEnumerable<RestaurantItemsSummaryCount>> GetRestaurantSummary(int restaurantId);
        public Task<bool> UpdateMenuItemFromId(int menuItemId, MenuItemDTO menuItemDTO);
        public Task<bool> AddMenuItem(int restaurantId, MenuItemDTO menuItemDTO);
        public Task<bool> DeleteMenuItemFromID(int menuItemId);
        public Task<RestaurantMenuDTO> GetMenuByOwnerId();

    }
    public class MicroserviceHandler : IMircoserviceHandler
    {
        private readonly ApiService _apiService;
        private const string _POSTGRESAPI_BASE_URL_RESTAURANTS = "https://localhost:7073/api/Restaurants";
        private const string _POSTGRESAPI_BASE_URL_USERS = "https://localhost:7073/api/Users";
        private const string _MONGOAPI_BASE_URL = "https://localhost:7061/api/Order";
        private const string _NEO4JAPI_BASE_URL = "https://localhost:7080/api/Recommendation";
        private readonly IConfiguration _configuration;
        private readonly HelperService _helperService;
        private readonly ApplicationCredentials _postgresClientCredentials;
        private readonly ApplicationCredentials _mongoDBClientCredentials;
        private readonly ApplicationCredentials _neo4jClientCredentials;
        private readonly TokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MicroserviceHandler(
            ApiService apiService,
            IConfiguration configuration,
            HelperService helperService,
            TokenService tokenService,
            IHttpContextAccessor httpContextAccesor)
        {
            _apiService = apiService;
            _configuration = configuration;
            _helperService = helperService;
            _postgresClientCredentials = _helperService.GetMicroserviceClientCredentials(HelperService.ClientType.PostgresClient);
            _mongoDBClientCredentials = _helperService.GetMicroserviceClientCredentials(HelperService.ClientType.MongoClient);
            _neo4jClientCredentials = _helperService.GetMicroserviceClientCredentials(HelperService.ClientType.Neo4jClient);
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccesor;
        }

        //--------------------------------------------- POSTGRESAPI ---------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {
            return await _apiService.Get<RestaurantDTO>(_POSTGRESAPI_BASE_URL_RESTAURANTS, _postgresClientCredentials);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public async Task<RestaurantMenuDTO> GetMenuFromRestaurantId(int restaurantId)
        {
            return await _apiService.GetSingle<RestaurantMenuDTO>(_POSTGRESAPI_BASE_URL_RESTAURANTS + "/" + restaurantId + "/menu", _postgresClientCredentials);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <param name="menuItemDTO"></param>
        /// <returns></returns>
        public async Task<bool> UpdateMenuItemFromId(int menuItemId, MenuItemDTO menuItemDTO)
        {
            string jsonString = JsonSerializer.Serialize(menuItemDTO);

            return await _apiService.Patch(_POSTGRESAPI_BASE_URL_RESTAURANTS + "/menu/menu-item/" + menuItemId, jsonString, _postgresClientCredentials);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <param name="menuItemDTO"></param>
        /// <returns></returns>
        public async Task<bool> AddMenuItem(int restaurantId, MenuItemDTO menuItemDTO)
        {
            string jsonString = JsonSerializer.Serialize(menuItemDTO);

            return await _apiService.Post(_POSTGRESAPI_BASE_URL_RESTAURANTS + "/" + restaurantId + "/menu/menu-item", jsonString, _postgresClientCredentials);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuItemId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteMenuItemFromID(int menuItemId)
        {
            return await _apiService.Delete(_POSTGRESAPI_BASE_URL_RESTAURANTS + "/menu/menu-item/" + menuItemId, _postgresClientCredentials);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> Register(RegisterUserDTO registerDto)
        {
            var jsonString = JsonSerializer.Serialize(registerDto);
            return await _apiService.Post(_POSTGRESAPI_BASE_URL_USERS + "/register", jsonString, _postgresClientCredentials);
        }

        //--------------------------------------------- NEO4J ---------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerEmail"></param>
        /// <returns></returns>
        public async Task<FavoriteRestaurantTypeDTO> FindFavoriteRestaurantFromCustomerEmail(string customerEmail)
        {
            return await _apiService.GetSingle<FavoriteRestaurantTypeDTO>(_NEO4JAPI_BASE_URL + "/favorite-restaurant-type/" + customerEmail, _neo4jClientCredentials);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        public async Task<TokenDTO> Login(LoginUserDTO loginDto)
        {
            var token = await _tokenService.RequestTokenForUser(loginDto.Username, loginDto.Password);
            return new TokenDTO() { AccessToken = token.Token.AccessToken, ExpiresIn = token.Token.ExpiresIn };
        }

        //--------------------------------------------- MONGOAPI ---------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="combinedDTO"></param>
        /// <returns></returns>
        public async Task<bool> CreateOrder(CombinedDTO combinedDTO)
        {
            var recommendationDTO = new RecommendationDTO()
            {
                CustomerEmail = combinedDTO.CustomerEmail,
                RestaurantName = combinedDTO.RestaurantName,
                RestaurantType = combinedDTO.RestaurantType
            };


            var orderDTO = new OrderDTO()
            {
                RestaurantId = combinedDTO.RestaurantId,
                RestaurantName = combinedDTO.RestaurantName,
                CustomerEmail = combinedDTO.CustomerEmail,
                Items = combinedDTO.Items
            };

            string recommendationJsonString = JsonSerializer.Serialize(recommendationDTO);
            string orderJsonString = JsonSerializer.Serialize(orderDTO);

            try
            {
                await _apiService.Post(_MONGOAPI_BASE_URL, orderJsonString, _mongoDBClientCredentials);
                await _apiService.Post(_NEO4JAPI_BASE_URL + "/order", recommendationJsonString, _neo4jClientCredentials);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> GetAllOrdersFromRestaurant(int restaurantId)
        {
            return await _apiService.Get<Order>(_MONGOAPI_BASE_URL + "/restaurant/" + restaurantId, _mongoDBClientCredentials);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerEmail"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> GetOrdersFromCustomer(string customerEmail)
        {
            return await _apiService.Get<Order>(_MONGOAPI_BASE_URL + "/customer/" + customerEmail, _mongoDBClientCredentials);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RestaurantItemsSummaryCount>> GetRestaurantSummary(int restaurantId)
        {
            return await _apiService.Get<RestaurantItemsSummaryCount>(_MONGOAPI_BASE_URL + "/restaurant-summary/" + restaurantId, _mongoDBClientCredentials);
        }

        public async Task<RestaurantMenuDTO> GetMenuByOwnerId()
        {
            var ownerId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _apiService.GetSingle<RestaurantMenuDTO>(_POSTGRESAPI_BASE_URL_RESTAURANTS + "/owner/" + ownerId + "/menu", _postgresClientCredentials);
        }
    }
}
