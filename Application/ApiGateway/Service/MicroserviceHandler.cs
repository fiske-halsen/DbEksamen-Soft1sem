using ApiGateway.DTO;
using ApiGateway.Models;
using Common.Models;
using System.Text.Json;

namespace ApiGateway.Service
{
    public interface IMircoserviceHandler
    {
        public Task<IEnumerable<RestaurantDTO>> GetAllRestaurants();
        public Task<IEnumerable<RestaurantMenuDTO>> GetMenuFromRestaurantId(int restaurantId);
        public Task<FavoriteRestaurantTypeDTO> FindFavoriteRestaurantFromCustomerEmail(string customerEmail);
        public Task<TokenDTO> Login(LoginUserDTO loginDto);
        public Task<TokenDTO> Register(RegisterUserDTO registerDto);
        public Task<bool> CreateOrder(CombinedDTO combinedDTO);
        public Task<IEnumerable<Order>> GetAllOrdersFromRestaurant(int restaurantId);
        public Task<IEnumerable<Order>> GetOrdersFromCustomer(string customerEmail);

        public Task<IEnumerable<RestaurantItemsSummaryCount>> GetRestaurantSummary(int restaurantId);

    }
    public class MicroserviceHandler : IMircoserviceHandler
    {
        private readonly ApiService _apiService;
        private const string _POSTGRESAPI_BASE_URL = "https://localhost:7073/api/Restaurants";
        private const string _MONGOAPI_BASE_URL = "https://localhost:7061/api/Order";
        private const string _NEO4JAPI_BASE_URL = "https://localhost:7080/api/Recommendation";
        private readonly IConfiguration _configuration;
        private readonly HelperService _helperService;
        private readonly ApplicationCredentials _postgresClientCredentials;
        private readonly ApplicationCredentials _mongoDBClientCredentials;
        private readonly ApplicationCredentials _neo4jClientCredentials;
        private readonly TokenService _tokenService;

        public MicroserviceHandler(
            ApiService apiService,
            IConfiguration configuration,
            HelperService helperService,
            TokenService tokenService)
        {
            _apiService = apiService;
            _configuration = configuration;
            _helperService = helperService;
            _postgresClientCredentials = _helperService.GetMicroserviceClientCredentials(HelperService.ClientType.PostgresClient);
            _mongoDBClientCredentials = _helperService.GetMicroserviceClientCredentials(HelperService.ClientType.MongoClient);
            _neo4jClientCredentials = _helperService.GetMicroserviceClientCredentials(HelperService.ClientType.Neo4jClient);
            _tokenService = tokenService;
        }

        //--------------------------------------------- POSTGRESAPI ---------------------------------------------
        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {
            return await _apiService.Get<RestaurantDTO>(_POSTGRESAPI_BASE_URL, _postgresClientCredentials);
        }

        public async Task<IEnumerable<RestaurantMenuDTO>> GetMenuFromRestaurantId(int restaurantId)
        {
            return await _apiService.Get<RestaurantMenuDTO>(_POSTGRESAPI_BASE_URL + "/" + restaurantId + "/menus", _postgresClientCredentials);
        }

        public Task<TokenDTO> Register(RegisterUserDTO registerDto)
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------- NEO4J ---------------------------------------------
        public async Task<FavoriteRestaurantTypeDTO> FindFavoriteRestaurantFromCustomerEmail(string customerEmail)
        {
            return await _apiService.GetSingle<FavoriteRestaurantTypeDTO>(_NEO4JAPI_BASE_URL + "/favorite-restaurant-type/" + customerEmail, _neo4jClientCredentials);
        }

        public async Task<TokenDTO> Login(LoginUserDTO loginDto)
        {
            var token = await _tokenService.RequestTokenForUser(loginDto.Username, loginDto.Password);
            return new TokenDTO() { AccessToken = token.Token.AccessToken, ExpiresIn = token.Token.ExpiresIn };
        }

        //--------------------------------------------- MONGOAPI ---------------------------------------------
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

        public async Task<IEnumerable<Order>> GetAllOrdersFromRestaurant(int restaurantId)
        {
            return await _apiService.Get<Order>(_MONGOAPI_BASE_URL + "/restaurant/" + restaurantId, _mongoDBClientCredentials);
        }

        public async Task<IEnumerable<Order>> GetOrdersFromCustomer(string customerEmail)
        {
            return await _apiService.Get<Order>(_MONGOAPI_BASE_URL + "/customer/" + customerEmail, _mongoDBClientCredentials);
        }

        public async Task<IEnumerable<RestaurantItemsSummaryCount>> GetRestaurantSummary(int restaurantId)
        {
            return await _apiService.Get<RestaurantItemsSummaryCount>(_MONGOAPI_BASE_URL + "/restaurant-summary/" + restaurantId, _mongoDBClientCredentials);
        }
    }
}
