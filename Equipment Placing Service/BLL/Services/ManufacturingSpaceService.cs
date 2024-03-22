using AutoMapper;
using Equipment_Placing_Service.BLL.DTOs;
using Equipment_Placing_Service.BLL.Services.Interfaces;
using Equipment_Placing_Service.DAL.Entities;
using Equipment_Placing_Service.DAL.Repositories.Interfaces;

namespace Equipment_Placing_Service.BLL.Services {
    public class ManufacturingSpaceService(IManufacturingSpaceRepository manufacturingSpaceRepository, IMapper mapper) : IManufacturingSpaceService {
        private readonly IManufacturingSpaceRepository _manufacturingSpaceRepository = manufacturingSpaceRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ManufacturingSpaceDto> GetByIdAsync(int id) {
            var manufacturingSpace = await _manufacturingSpaceRepository.GetByIdAsync(id);
            return _mapper.Map<ManufacturingSpaceDto>(manufacturingSpace);
        }

        public async Task<ManufacturingSpaceDto> GetByCodeAsync(string code) {
            var manufacturingSpace = await _manufacturingSpaceRepository.GetByCodeAsync(code);
            return _mapper.Map<ManufacturingSpaceDto>(manufacturingSpace);
        }

        public async Task<List<ManufacturingSpaceDto>> GetAllAsync() {
            var manufacturingSpaces = await _manufacturingSpaceRepository.GetAllAsync();
            return _mapper.Map<List<ManufacturingSpaceDto>>(manufacturingSpaces);
        }

        public async Task CreateAsync(CreateManufacturingSpaceDto createManufacturingSpaceDto) {
            var manufacturingSpace = _mapper.Map<ManufacturingSpace>(createManufacturingSpaceDto);
            await _manufacturingSpaceRepository.AddAsync(manufacturingSpace);
        }

        public async Task UpdateAsync(int id, UpdateManufacturingSpaceDto updateManufacturingSpaceDto) {
            var manufacturingSpace = await _manufacturingSpaceRepository.GetByIdAsync(id);
            _mapper.Map(updateManufacturingSpaceDto, manufacturingSpace);
            await _manufacturingSpaceRepository.UpdateAsync(manufacturingSpace);
        }

        public async Task DeleteAsync(int id) {
            var manufacturingSpace = await _manufacturingSpaceRepository.GetByIdAsync(id);
            await _manufacturingSpaceRepository.DeleteAsync(manufacturingSpace);
        }
    }

}
