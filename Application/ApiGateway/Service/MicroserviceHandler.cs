using ApiGateway.Models;
using Common.Models;
using Neo4JAPI.DTO;

namespace ApiGateway.Service
{
    public interface IMircoserviceHandler
    {
        public Task<IEnumerable<RestaurantDTO>> GetAllRestaurants();
        public Task<FavoriteRestaurantTypeDTO> FindFavoriteRestaurantFromCustomerEmail(string customerEmail);
        public Task<TokenDTO> Login(LoginUserDTO loginDto);
        public Task<TokenDTO> Register(RegisterUserDTO registerDto);
    }
    public class MicroserviceHandler : IMircoserviceHandler
    {
        private readonly ApiService _apiService;
        private const string _POSTGRESAPI_BASE_URL = "https://localhost:7073/api/Restaurants";
        private const string _MONGOAPI_BASE_URL = "https://localhost:7061/api/Orders";
        private const string _NEO4JAPI_BASE_URL = "https://localhost:7080";
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

        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {
            return await _apiService.Get<RestaurantDTO>(_POSTGRESAPI_BASE_URL, _postgresClientCredentials);
        }

        public async Task<FavoriteRestaurantTypeDTO> FindFavoriteRestaurantFromCustomerEmail(string customerEmail)
        {
            return await _apiService.GetSingle<FavoriteRestaurantTypeDTO>(_NEO4JAPI_BASE_URL + "/favorite-restaurant-type/" + customerEmail, _neo4jClientCredentials);
        }

        public async Task<TokenDTO> Login(LoginUserDTO loginDto)
        {
            var token = await _tokenService.RequestTokenForUser(loginDto.Username, loginDto.Password);
            return new TokenDTO() { AccessToken = token.Token.AccessToken, ExpiresIn = token.Token.ExpiresIn};
        }
        public Task<TokenDTO> Register(RegisterUserDTO registerDto)
        {
            // TÓDO
        }
    }
}
