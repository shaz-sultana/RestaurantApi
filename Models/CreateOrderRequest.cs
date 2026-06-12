namespace RestaurantApi.Models;

public class CreateOrderRequest
{
    public int ItemId { get; set; }
    public int Quantity { get; set; }
}
