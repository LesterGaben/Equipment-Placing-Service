namespace Equipment_Placing_Service.BLL.DTOs {
    public class CreateEquipmentPlacementContractDto {
        public string ManufacturingSpaceCode { get; set; }
        public string EquipmentTypeCode { get; set; }
        public int Quantity { get; set; }
    }

    public class EquipmentPlacementContractDto {
        public int Id { get; set; }
        public string ManufacturingSpaceName { get; set; }
        public string EquipmentTypeName { get; set; }
        public int Quantity { get; set; }
    }

}
