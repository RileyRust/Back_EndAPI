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

    [HttpGet]
    public async Task<ActionResult<InventoryListResponse>> GetInventory([FromQuery] int? productId)
    {
        var result = await _service.GetInventoryAsync(productId);

        if (productId.HasValue && result.Items.Count == 0)
            return NotFound();

        return Ok(result);
    }
}
