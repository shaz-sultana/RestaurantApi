using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Models;

namespace RestaurantApi.Controllers;

[ApiController]
[Route("api/menu")]
public class MenuController : ControllerBase
{
    public static List<MenuItem> MenuItems = new()
    {
        new MenuItem { Id = 1, Name = "Chicken Burger", Price = 8.99m, Available = true },
        new MenuItem { Id = 2, Name = "Pizza", Price = 12.99m, Available = true },
        new MenuItem { Id = 3, Name = "French Fries", Price = 4.99m, Available = true }
    };

    [HttpGet]
    public IActionResult GetMenu()
    {
        // Interview concept: This data can be cached in Redis for faster performance.
        return Ok(MenuItems);
    }

    [HttpPost]
    public IActionResult AddMenuItem(MenuItem item)
    {
        item.Id = MenuItems.Count == 0 ? 1 : MenuItems.Max(x => x.Id) + 1;
        MenuItems.Add(item);

        // Interview concept: Menu update can trigger synchronization with POS systems.
        return Ok(item);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMenuItem(int id, MenuItem updatedItem)
    {
        var item = MenuItems.FirstOrDefault(x => x.Id == id);

        if (item == null)
            return NotFound("Menu item not found");

        item.Name = updatedItem.Name;
        item.Price = updatedItem.Price;
        item.Available = updatedItem.Available;

        return Ok(item);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMenuItem(int id)
    {
        var item = MenuItems.FirstOrDefault(x => x.Id == id);

        if (item == null)
            return NotFound("Menu item not found");

        MenuItems.Remove(item);
        return Ok("Menu item deleted successfully");
    }
}
