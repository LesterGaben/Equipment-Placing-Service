using AutoMapper;
using Equipment_Placing_Service.BLL.DTOs;
using Equipment_Placing_Service.BLL.Services.Interfaces;
using Equipment_Placing_Service.DAL.Entities;
using Equipment_Placing_Service.DAL.Repositories.Interfaces;

namespace Equipment_Placing_Service.BLL.Services {
    public class EquipmentTypeService(IEquipmentTypeRepository equipmentTypeRepository, IMapper mapper) : IEquipmentTypeService {
        private readonly IEquipmentTypeRepository _equipmentTypeRepository = equipmentTypeRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<EquipmentTypeDto> GetByIdAsync(int id) {
            var equipmentType = await _equipmentTypeRepository.GetByIdAsync(id);
            return _mapper.Map<EquipmentTypeDto>(equipmentType);
        }

        public async Task<List<EquipmentTypeDto>> GetAllAsync() {
            var equipmentTypes = await _equipmentTypeRepository.GetAllAsync();
            return _mapper.Map<List<EquipmentTypeDto>>(equipmentTypes);
        }

        public async Task CreateAsync(CreateEquipmentTypeDto createEquipmentTypeDto) {
            var equipmentType = _mapper.Map<EquipmentType>(createEquipmentTypeDto);
            await _equipmentTypeRepository.AddAsync(equipmentType);
        }

        public async Task UpdateAsync(int id, UpdateEquipmentTypeDto updateEquipmentTypeDto) {
            var equipmentType = await _equipmentTypeRepository.GetByIdAsync(id);
            
            _mapper.Map(updateEquipmentTypeDto, equipmentType);
            await _equipmentTypeRepository.UpdateAsync(equipmentType);
        }

        public async Task DeleteAsync(int id) {
            var equipmentType = await _equipmentTypeRepository.GetByIdAsync(id);
            await _equipmentTypeRepository.DeleteAsync(equipmentType);
        }
    }

}
