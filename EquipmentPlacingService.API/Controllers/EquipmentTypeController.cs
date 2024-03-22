using Equipment_Placing_Service.BLL.DTOs;
using Equipment_Placing_Service.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentPlacingService.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentTypeController(IEquipmentTypeService service) : ControllerBase {
        private readonly IEquipmentTypeService _service = service;

        [HttpPost]
        public async Task<IActionResult> Create(CreateEquipmentTypeDto dto) {
            await _service.CreateAsync(dto);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var types = await _service.GetAllAsync();
            return Ok(types);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var type = await _service.GetByIdAsync(id);
            return Ok(type);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEquipmentTypeDto dto) {
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
