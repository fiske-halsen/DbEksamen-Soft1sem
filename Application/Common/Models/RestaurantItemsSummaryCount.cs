namespace Common.Models;

public class RestaurantItemsSummaryCount
{
    public string ItemName { get; set; } = null!;
    public int Count { get; set; }
    public double TotalPrice { get; set; }
}
