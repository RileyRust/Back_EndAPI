using Back_EndAPI.Models.Orders;
using Back_EndAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back_EndAPI.Controllers;

[ApiController]
[Route("orders")]
public class OrdersController : ControllerBase
{
    private readonly OrderService _service;

    public OrdersController(OrderService service)
    {
        _service = service;
    }

    [HttpPost("{id:int}/pick")]
    public async Task<ActionResult<OrderResponse>> Pick(int id)
    {
        var result = await _service.PickAsync(id);
        return Ok(result);
    }

    [HttpPost("{id:int}/pack")]
    public async Task<ActionResult<OrderResponse>> Pack(int id)
    {
        var result = await _service.PackAsync(id);
        return Ok(result);
    }

    [HttpPost("{id:int}/ship")]
    public async Task<ActionResult<OrderResponse>> Ship(int id)
    {
        var result = await _service.ShipAsync(id);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetStatus(int id)
    {
        var result = await _service.GetStatusAsync(id);

        if (result == null)
            return NotFound(new { error = "Order not found." });

        return Ok(result);
    }
}
