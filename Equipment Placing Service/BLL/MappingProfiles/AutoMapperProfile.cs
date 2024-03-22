using AutoMapper;
using Equipment_Placing_Service.BLL.DTOs;
using Equipment_Placing_Service.DAL.Entities;

namespace Equipment_Placing_Service.BLL.MappingProfiles {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {

            CreateMap<EquipmentPlacementContract, EquipmentPlacementContractDto>()
                .ForMember(dest => dest.ManufacturingSpaceName, opt => opt.MapFrom(src => src.ManufacturingSpace.Description))
                .ForMember(dest => dest.EquipmentTypeName, opt => opt.MapFrom(src => src.EquipmentType.Description));
            CreateMap<CreateEquipmentPlacementContractDto, EquipmentPlacementContract>();

            CreateMap<ManufacturingSpace, ManufacturingSpaceDto>();
            CreateMap<CreateManufacturingSpaceDto, ManufacturingSpace>();
            CreateMap<UpdateManufacturingSpaceDto, ManufacturingSpace>();

            CreateMap<EquipmentType, EquipmentTypeDto>();
            CreateMap<CreateEquipmentTypeDto, EquipmentType>();
            CreateMap<UpdateEquipmentTypeDto, EquipmentType>();
        }
    }
}
