using Back_EndAPI.Models.Shipments;
using Back_EndAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Back_EndAPI.Controllers;

[ApiController]
[Route("shipments")]
public class ShipmentController : ControllerBase
{
    private readonly ShipmentService _service;

    public ShipmentController(ShipmentService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateShipmentRequest request)
    {
        var id = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPost("{id:int}/receive")]
    public async Task<IActionResult> Receive(int id, ReceiveShipmentRequest request)
    {
        await _service.ReceiveAsync(id, request);
        return Ok();
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return Ok(); // optional for assignment
    }
}
