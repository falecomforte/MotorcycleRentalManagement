using Microsoft.AspNetCore.Mvc;
using MotorcycleRentalManagement.Application.Services;
using MotorcycleRentalManagement.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleRentalManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotorcycleController : ControllerBase
    {
        private readonly RentalService _rentalService;

        public MotorcycleController(RentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMotorcycle([FromBody] MotorcycleDto motorcycleDto)
        {
            var result = await _rentalService.AddMotorcycleAsync(motorcycleDto);
            return CreatedAtAction(nameof(GetMotorcycles), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotorcycleDto>>> GetMotorcycles()
        {
            var motorcycles = await _rentalService.GetMotorcyclesAsync();
            return Ok(motorcycles);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMotorcycle(string id, [FromBody] MotorcycleDto motorcycleDto)
        {
            var result = await _rentalService.UpdateMotorcycleAsync(id, motorcycleDto);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotorcycle(string id)
        {
            var result = await _rentalService.DeleteMotorcycleAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}