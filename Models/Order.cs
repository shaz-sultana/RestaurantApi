namespace RestaurantApi.Models;

public class Order
{
    public int OrderId { get; set; }
    public int ItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = "Placed";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
