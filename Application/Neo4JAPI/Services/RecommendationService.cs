﻿using Neo4j.Driver;
using Neo4JAPI.Repository;

namespace Neo4JAPI.Services
{

    public interface IRecommendationService
    {
        public Task AddCustomerRestaurantRelation(string restaurantName, string customerName);
        public Task AddRestaurantTypeRelation(string restaurantName, string restaurantType);
        public Task <string> FindFavoriteRestaurantFromCustomerName(string customerName);
    }
    public class RecommendationService : IRecommendationService
    {

        private readonly IRecommendationRepository _recommendationRepository;

        public RecommendationService(IRecommendationRepository recommendationRepository)
        {
            _recommendationRepository = recommendationRepository;
        }

        public async Task AddCustomerRestaurantRelation(string restaurantName, string customerName)
        {
            await _recommendationRepository.AddCustomerRestaurantRelation(restaurantName, customerName);
        }

        public async Task AddRestaurantTypeRelation(string restaurantName, string restaurantType)
        {
            await _recommendationRepository.AddRestaurantTypeRelation(restaurantName, restaurantType);
        }

        public async Task <string> FindFavoriteRestaurantFromCustomerName(string customerName)
        {
           return await _recommendationRepository.FindFavoriteRestaurantFromCustomerName(customerName);
        }
    }
}