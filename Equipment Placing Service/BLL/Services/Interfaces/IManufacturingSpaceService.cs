using Equipment_Placing_Service.BLL.DTOs;

namespace Equipment_Placing_Service.BLL.Services.Interfaces {
    public interface IManufacturingSpaceService {
        public Task<ManufacturingSpaceDto> GetByIdAsync(int id);
        public Task<ManufacturingSpaceDto> GetByCodeAsync(string code);

        public Task<List<ManufacturingSpaceDto>> GetAllAsync();

        public Task CreateAsync(CreateManufacturingSpaceDto createManufacturingSpaceDto);

        public Task UpdateAsync(int id, UpdateManufacturingSpaceDto updateManufacturingSpaceDto);

        public Task DeleteAsync(int id);
    }
}
