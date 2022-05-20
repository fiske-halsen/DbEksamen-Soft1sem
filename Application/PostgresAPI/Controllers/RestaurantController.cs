using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PostgresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        //[HttpGet("")]
        //public IEnumerable<dynamic> GetAllRestaurants()
        //{
        //    return 1;
        //}
        //[HttpGet("/{int:restaurantId}/menu")]
        //public IEnumerable<dynamic> GetMenuFromRestaurantId(int restaurantId)
        //{
            
        //    return 1;
        //}
        ////TODO: only correct owner
        //[HttpPatch("/menu/{int:menuItemId}")]
        //public IEnumerable<dynamic> UpdateMenuItemFromId(int menuItemId)
        //{
        //    return 1;
        //}
        //[HttpPost("/menu")]
        //public IEnumerable<dynamic> AddMenuItem()
        //{
        //    return 1;
        //}
        //[HttpDelete("/menu/{int:menuItemId}")]
        //public IEnumerable<dynamic> DeleteMenuItemFromId(int menuItemId)
        //{
        //    return 1;
        //}

    }
}
