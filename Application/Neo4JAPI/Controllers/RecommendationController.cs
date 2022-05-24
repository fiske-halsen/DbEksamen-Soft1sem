using Microsoft.AspNetCore.Mvc;
using Neo4JAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class RecommendationController : ControllerBase
{

    private readonly IRecommendationService _recommendationService;
    public RecommendationController(IRecommendationService recommendationService)
    {
        _recommendationService = recommendationService;
    }




    [HttpPost("/customer-restaurant-relation/{restaurantName}/{customerName}")]
    public async Task AddCustomerRestaurantRelation(string restaurantName, string customerName)
    {
       await _recommendationService.AddCustomerRestaurantRelation(restaurantName, customerName);
    }

    [HttpPost("/restaurant-type-relation/{restaurantName}/{restaurantType}")]
    public async Task AddRestaurantTypeRelation(string restaurantName, string restaurantType)
    {
        await _recommendationService.AddRestaurantTypeRelation(restaurantName, restaurantType);
    }
}