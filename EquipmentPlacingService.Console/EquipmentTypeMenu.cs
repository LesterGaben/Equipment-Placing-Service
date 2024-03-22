using Equipment_Placing_Service.BLL.DTOs;
using Equipment_Placing_Service.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentPlacingService.Console {
    public class EquipmentTypeMenu(IServiceProvider serviceProvider) {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public void ShowMenu() {
            var equipmentTypeService = _serviceProvider.GetService<IEquipmentTypeService>();

            bool showMenu = true;
            while (showMenu) {
                System.Console.WriteLine("\nChoose an option for Equipment Types:");
                System.Console.WriteLine("1) List all Equipment Types");
                System.Console.WriteLine("2) Get Equipment Type by ID");
                System.Console.WriteLine("3) Create Equipment Type");
                System.Console.WriteLine("4) Delete Equipment Type by ID");
                System.Console.WriteLine("5) Exit to main menu");
                System.Console.Write("\r\nSelect an option: ");

                switch (System.Console.ReadLine()) {
                    case "1":
                        ListAllEquipmentTypes(equipmentTypeService).Wait();
                        break;
                    case "2":
                        GetEquipmentTypeById(equipmentTypeService).Wait();
                        break;
                    case "3":
                        CreateEquipmentType(equipmentTypeService).Wait();
                        break;
                    case "4":
                        DeleteEquipmentTypeById(equipmentTypeService).Wait();
                        break;
                    case "5":
                        showMenu = false;
                        break;
                    default:
                        System.Console.WriteLine("\nInvalid option, try again.");
                        break;
                }
            }
        }

        private async Task ListAllEquipmentTypes(IEquipmentTypeService service) {
            var types = await service.GetAllAsync();
            System.Console.WriteLine("\nAll Equipment Types:");
            foreach (var type in types) {
                System.Console.WriteLine($"ID: {type.Id}, Code: {type.Code}, Description: {type.Description}, Area: {type.Area}");
            }
        }

        private async Task GetEquipmentTypeById(IEquipmentTypeService service) {
            System.Console.Write("\nEnter Equipment Type ID: ");
            if (int.TryParse(System.Console.ReadLine(), out int id)) {
                var type = await service.GetByIdAsync(id);
                if (type != null) {
                    System.Console.WriteLine($"ID: {type.Id}, Code: {type.Code}, Description: {type.Description}, Area: {type.Area}");
                }
                else {
                    System.Console.WriteLine("\nEquipment Type not found.");
                }
            }
            else {
                System.Console.WriteLine("\nInvalid input, enter a numeric value.");
            }
        }

        private async Task CreateEquipmentType(IEquipmentTypeService service) {
            var newType = new CreateEquipmentTypeDto();

            System.Console.Write("\nEnter Equipment Type Code: ");
            newType.Code = System.Console.ReadLine();

            System.Console.Write("Enter Equipment Type Description: ");
            newType.Description = System.Console.ReadLine();

            System.Console.Write("Enter Equipment Type Area: ");
            newType.Area = Double.Parse(System.Console.ReadLine());

            await service.CreateAsync(newType);
            System.Console.WriteLine("\nEquipment Type created successfully.");
        }

        private async Task DeleteEquipmentTypeById(IEquipmentTypeService service) {
            System.Console.Write("\nEnter Equipment Type ID to delete: ");
            if (int.TryParse(System.Console.ReadLine(), out int id)) {
                await service.DeleteAsync(id);
                System.Console.WriteLine("\nEquipment Type deleted successfully.");
            }
            else {
                System.Console.WriteLine("\nInvalid input, enter a numeric value.");
            }
        }
    }

}
