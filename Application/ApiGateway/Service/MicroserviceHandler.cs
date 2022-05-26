using Neo4JAPI.DTO;
using PostgresAPI.DTO;

namespace ApiGateway.Service
{
    public interface IMircoserviceHandler
    {
        public Task<IEnumerable<RestaurantDTO>> GetAllRestaurants();
        public Task<FavoriteRestaurantTypeDTO> FindFavoriteRestaurantFromCustomerEmail(string customerEmail);
    }
    public class MicroserviceHandler : IMircoserviceHandler
    {
        private readonly ApiService _apiService;
        private readonly TokenService _tokenService;
        private const string _POSTGRESAPI_URL = "https://localhost:7073/api/Restaurants";
        private const string _MONGOAPI_URL = "https://localhost:7061/api/Orders";
        private const string _NEO4JAPI_URL = "https://localhost:7080";
        private readonly IConfiguration _configuration;
        public MicroserviceHandler(ApiService apiService, IConfiguration configuration)
        {
            _apiService = apiService;
            _configuration = configuration;
        }

        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {

            return await _apiService.Get<RestaurantDTO>(_POSTGRESAPI_URL,
                new Models.ApplicationCredentials()
                {
                    ClientId = _configuration["PostgresAPI:ClientId"],
                    ClientSecret = _configuration["PostgresAPI:Key"],
                    Scope = _configuration["PostgresAPI:Scope"]
                });

        }


        public async Task <FavoriteRestaurantTypeDTO> FindFavoriteRestaurantFromCustomerEmail(string customerEmail)
        {
            return await _apiService.GetSingle<FavoriteRestaurantTypeDTO>(_NEO4JAPI_URL + "/favorite-restaurant-type/" + customerEmail,
                new Models.ApplicationCredentials()
                {
                    ClientId = _configuration["Neo4jAPI:ClientId"],
                    ClientSecret = _configuration["Neo4jAPI:Key"],
                    Scope = _configuration["Neo4jAPI:Scope"]
                });
        }
    }
}
