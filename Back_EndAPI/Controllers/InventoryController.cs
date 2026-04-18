using Back_EndAPI.Models.Inventory;
using Back_EndAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Back_EndAPI.Controllers;

[ApiController]
[Route("inventory")]
public class InventoryController : ControllerBase
{
    private readonly InventoryService _service;

    public InventoryController(InventoryService service)
    {
        _service = service;
    }

    [HttpPost("store")]
    public async Task<ActionResult<InventoryResponse>> Store(StoreInventoryRequest request)
    {
        var result = await _service.StoreAsync(request);
        return Ok(result);
    }
}
