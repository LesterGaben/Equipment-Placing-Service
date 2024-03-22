using AutoMapper;
using Equipment_Placing_Service.BLL.DTOs;
using Equipment_Placing_Service.BLL.Services.Interfaces;
using Equipment_Placing_Service.DAL.Entities;
using Equipment_Placing_Service.DAL.Repositories.Interfaces;

namespace Equipment_Placing_Service.BLL.Services {
    public class EquipmentPlacementContractService : IEquipmentPlacementContractService {
        private readonly IEquipmentPlacementContractRepository _contractRepository;
        private readonly IManufacturingSpaceRepository _spaceRepository;
        private readonly IEquipmentTypeRepository _typeRepository;
        private readonly IMapper _mapper;

        public EquipmentPlacementContractService(
            IEquipmentPlacementContractRepository contractRepository,
            IManufacturingSpaceRepository spaceRepository,
            IEquipmentTypeRepository typeRepository,
            IMapper mapper) {
            _contractRepository = contractRepository;
            _spaceRepository = spaceRepository;
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateEquipmentPlacementContractDto dto) {
            var space = await _spaceRepository.GetByCodeAsync(dto.ManufacturingSpaceCode);
            var type = await _typeRepository.GetByCodeAsync(dto.EquipmentTypeCode);

            if (space == null || type == null) {
                throw new Exception("Manufacturing space or equipment type not found.");
            }

            if (space.EquipmentArea < type.Area * dto.Quantity) {
                throw new Exception("Insufficient space for the equipment.");
            }

            var contract = new EquipmentPlacementContract {
                ManufacturingSpaceId = space.Id,
                EquipmentTypeId = type.Id,
                Quantity = dto.Quantity
            };

            await _contractRepository.AddAsync(contract);
        }

        public async Task<List<EquipmentPlacementContractDto>> GetAllAsync() {
            var contracts = await _contractRepository.GetAllAsync();
            var contractDtos = new List<EquipmentPlacementContractDto>();

            foreach (var contract in contracts) {
                var dto = _mapper.Map<EquipmentPlacementContractDto>(contract);
                dto.ManufacturingSpaceName = (await _spaceRepository.GetByIdAsync(contract.ManufacturingSpaceId)).Description;
                dto.EquipmentTypeName = (await _typeRepository.GetByIdAsync(contract.EquipmentTypeId)).Description;
                contractDtos.Add(dto);
            }

            return contractDtos;
        }

        public async Task<EquipmentPlacementContractDto> GetByIdAsync(int id) {
            var contract = await _contractRepository.GetByIdAsync(id);
            if (contract == null) {
                throw new Exception($"Contract with id {id} not found.");
            }
            var contractDto = _mapper.Map<EquipmentPlacementContractDto>(contract);
            contractDto.ManufacturingSpaceName = (await _spaceRepository.GetByIdAsync(contract.ManufacturingSpaceId)).Description;
            contractDto.EquipmentTypeName = (await _typeRepository.GetByIdAsync(contract.EquipmentTypeId)).Description;
            return contractDto;
        }

        public async Task DeleteAsync(int id) {
            var contract = await _contractRepository.GetByIdAsync(id);
            if (contract == null) {
                throw new Exception($"Contract with id {id} not found.");
            }
            await _contractRepository.DeleteAsync(contract);
        }
    }

}
