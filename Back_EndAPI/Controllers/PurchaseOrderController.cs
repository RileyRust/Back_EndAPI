using Back_EndAPI.Models.PurchaseOrders;
using Back_EndAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back_EndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly PurchaseOrderService _service;

        public PurchaseOrderController(PurchaseOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePurchaseOrderRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.CreateAsync(request);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Not required for this assignment
            return Ok();
        }
    }
}
