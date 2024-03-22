using Equipment_Placing_Service.BLL.DTOs;
using Equipment_Placing_Service.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentPlacingService.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturingSpaceController(IManufacturingSpaceService service) : ControllerBase {
        private readonly IManufacturingSpaceService _service = service;

        [HttpPost]
        public async Task<IActionResult> Create(CreateManufacturingSpaceDto dto) {
            await _service.CreateAsync(dto);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var spaces = await _service.GetAllAsync();
            return Ok(spaces);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var space = await _service.GetByIdAsync(id);
            return Ok(space);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateManufacturingSpaceDto dto) {
            await _service.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
