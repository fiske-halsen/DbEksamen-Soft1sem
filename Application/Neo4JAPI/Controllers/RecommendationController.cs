using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neo4JAPI.DTO;
using Neo4JAPI.Services;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class RecommendationController : ControllerBase
{
    private readonly IRecommendationService _recommendationService;
    public RecommendationController(IRecommendationService recommendationService)
    {
        _recommendationService = recommendationService;
    }

    [HttpPost("/order")]
    public async Task AddCustomerRestaurantRelation(OrderDTO orderDTO)
    {
        await _recommendationService.AddCustomerRestaurantRelation(orderDTO);
    }

    [HttpGet("/favorite-restaurant-type/{customerEmail}")]
    public async Task<FavoriteRestaurantTypeDTO> FindFavoriteRestaurantFromCustomerName(string customerEmail)
    {
        return await _recommendationService.FindFavoriteRestaurantFromCustomerEmail(customerEmail);
    }
}