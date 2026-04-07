using Back_EndAPI.Models.Shipments;
using Back_EndAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back_EndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentController : ControllerBase
    {
        private readonly ShipmentService _service;

        public ShipmentController(ShipmentService service)
        {
            _service = service;
        }

        [HttpPost("receive")]
        public async Task<IActionResult> ReceiveShipment([FromBody] ReceiveShipmentRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _service.ReceiveShipmentAsync(request);
                return Ok(new { message = "Shipment received successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
