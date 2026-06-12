using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Models;

namespace RestaurantApi.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private static List<Order> Orders = new();

    [HttpGet]
    public IActionResult GetOrders()
    {
        return Ok(Orders);
    }

    [HttpPost]
    public IActionResult CreateOrder(CreateOrderRequest request)
    {
        var menuItem = MenuController.MenuItems.FirstOrDefault(x => x.Id == request.ItemId);

        if (menuItem == null)
            return NotFound("Menu item not found");

        if (!menuItem.Available)
            return BadRequest("Menu item is currently not available");

        if (request.Quantity <= 0)
            return BadRequest("Quantity must be greater than zero");

        var order = new Order
        {
            OrderId = Orders.Count == 0 ? 101 : Orders.Max(x => x.OrderId) + 1,
            ItemId = menuItem.Id,
            ItemName = menuItem.Name,
            Quantity = request.Quantity,
            TotalPrice = menuItem.Price * request.Quantity,
            Status = "Placed",
            CreatedAt = DateTime.UtcNow
        };

        Orders.Add(order);

        // Interview concept: This is where we can publish an event to Kafka/RabbitMQ.
        Console.WriteLine($"EVENT: OrderCreated - OrderId: {order.OrderId}");

        // Interview concept: This is where we can call a webhook to notify kitchen/POS system.
        Console.WriteLine($"WEBHOOK: Notifying kitchen system for order {order.OrderId}");

        return Ok(order);
    }
}
