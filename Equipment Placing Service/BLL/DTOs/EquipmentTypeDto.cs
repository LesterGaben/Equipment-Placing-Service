namespace Equipment_Placing_Service.BLL.DTOs {
    public class EquipmentTypeDto {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double Area { get; set; }
    }

    public class CreateEquipmentTypeDto {
        public string Code { get; set; }
        public string Description { get; set; }
        public double Area { get; set; }
    }

    public class UpdateEquipmentTypeDto {
        public string Description { get; set; }
        public double Area { get; set; }
    }
}
