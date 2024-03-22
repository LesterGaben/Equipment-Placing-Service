namespace Equipment_Placing_Service.BLL.DTOs {
    public class ManufacturingSpaceDto {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double EquipmentArea { get; set; }
    }

    public class CreateManufacturingSpaceDto {
        public string Code { get; set; }
        public string Description { get; set; }
        public double EquipmentArea { get; set; }
    }

    public class UpdateManufacturingSpaceDto {
        public string Description { get; set; }
        public double EquipmentArea { get; set; }
    }
}
