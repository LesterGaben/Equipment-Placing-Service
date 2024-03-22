namespace Equipment_Placing_Service.DAL.Entities {
    public class EquipmentPlacementContract {
        public int Id { get; set; } 
        public int ManufacturingSpaceId { get; set; } 
        public ManufacturingSpace ManufacturingSpace { get; set; } 
        public int EquipmentTypeId { get; set; } 
        public EquipmentType EquipmentType { get; set; } 
        public int Quantity { get; set; } 
    }

}
