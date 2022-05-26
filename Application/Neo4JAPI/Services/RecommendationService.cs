using Neo4j.Driver;
using Neo4JAPI.DTO;
using Neo4JAPI.Repository;

namespace Neo4JAPI.Services
{

    public interface IRecommendationService
    {
        public Task AddCustomerRestaurantRelation(OrderDTO orderDTO);
        public Task<FavoriteRestaurantTypeDTO> FindFavoriteRestaurantFromCustomerEmail(string customerEmail);
    }
    public class RecommendationService : IRecommendationService
    {

        private readonly IRecommendationRepository _recommendationRepository;

        public RecommendationService(IRecommendationRepository recommendationRepository)
        {
            _recommendationRepository = recommendationRepository;
        }

        public async Task AddCustomerRestaurantRelation(OrderDTO orderDTO)
        {
            await _recommendationRepository.AddCustomerRestaurantRelation(orderDTO);
        }

        public async Task<FavoriteRestaurantTypeDTO> FindFavoriteRestaurantFromCustomerEmail(string customerEmail)
        {
            return await _recommendationRepository.FindFavoriteRestaurantFromCustomerEmail(customerEmail);
        }
    }
}
