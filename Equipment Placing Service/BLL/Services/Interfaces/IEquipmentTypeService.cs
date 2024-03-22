using Equipment_Placing_Service.BLL.DTOs;

namespace Equipment_Placing_Service.BLL.Services.Interfaces {
    public interface IEquipmentTypeService {
        public Task<EquipmentTypeDto> GetByIdAsync(int id);

        public Task<List<EquipmentTypeDto>> GetAllAsync();

        public Task CreateAsync(CreateEquipmentTypeDto createEquipmentTypeDto);

        public Task UpdateAsync(int id, UpdateEquipmentTypeDto updateEquipmentTypeDto);

        public Task DeleteAsync(int id);
    }
}
