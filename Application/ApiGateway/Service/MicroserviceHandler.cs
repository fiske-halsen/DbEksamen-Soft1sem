using PostgresAPI.DTO;

namespace ApiGateway.Service
{
    public interface IMircoserviceHandler
    {
        public Task<IEnumerable<RestaurantDTO>> GetAllRestaurants();

    }
    public class MicroserviceHandler : IMircoserviceHandler
    {
        private readonly ApiService _apiService;
        private readonly TokenService _tokenService;
        private const string _POSTGRESAPI_URL = "https://localhost:7073/api/Restaurants";

        public MicroserviceHandler(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IEnumerable<RestaurantDTO>> GetAllRestaurants()
        {

            return await _apiService.Get<RestaurantDTO>(_POSTGRESAPI_URL,
                new Models.ApplicationCredentials()
                {
                    ClientId = "Postgres",
                    ClientSecret = "437828E5-D1DC-4882-8B34-4DCC78306924",
                    Scope = "PostgresAPI"
                });

        }
    }
}
