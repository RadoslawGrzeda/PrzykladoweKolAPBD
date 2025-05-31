using Microsoft.AspNetCore.Mvc;
using PrzykładKol.Properties.Service;

namespace PrzykładKol.Properties.Controllers;

[ApiController]
[Route("api/Orders")]
public class OrderControllers:ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderControllers(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet ("{id}")]
    public async Task<IActionResult> GetOrders(int id)
    {
        var thisOrder = await _orderService.GetOrderById(id);
        return Ok(thisOrder);
    }
    
}