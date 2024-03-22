using Equipment_Placing_Service.BLL.DTOs;
using Equipment_Placing_Service.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentPlacingService.API.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentPlacementContractController(IEquipmentPlacementContractService service) : ControllerBase {
        private readonly IEquipmentPlacementContractService _service = service;

        [HttpPost]
        public async Task<IActionResult> Create(CreateEquipmentPlacementContractDto dto) {
            await _service.CreateAsync(dto);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var contracts = await _service.GetAllAsync();
            return Ok(contracts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var contract = await _service.GetByIdAsync(id);
            return Ok(contract);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
