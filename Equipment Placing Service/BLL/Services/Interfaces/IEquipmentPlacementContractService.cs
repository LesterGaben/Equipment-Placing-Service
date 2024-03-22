using Equipment_Placing_Service.BLL.DTOs;

namespace Equipment_Placing_Service.BLL.Services.Interfaces {
    public interface IEquipmentPlacementContractService {
        public Task CreateAsync(CreateEquipmentPlacementContractDto dto);

        public Task<List<EquipmentPlacementContractDto>> GetAllAsync();

        public Task<EquipmentPlacementContractDto> GetByIdAsync(int id);

        public Task DeleteAsync(int id);
    }
}
