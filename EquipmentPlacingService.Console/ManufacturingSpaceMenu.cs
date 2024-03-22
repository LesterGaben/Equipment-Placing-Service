using Equipment_Placing_Service.BLL.DTOs;
using Equipment_Placing_Service.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentPlacingService.Console {
    public class ManufacturingSpaceMenu(IServiceProvider serviceProvider) {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public void ShowMenu() {
            var manufacturingSpaceService = _serviceProvider.GetService<IManufacturingSpaceService>();

            bool showMenu = true;
            while (showMenu) {
                System.Console.WriteLine("\nChoose an option for Manufacturing Spaces:");
                System.Console.WriteLine("1) List all Manufacturing Spaces");
                System.Console.WriteLine("2) Get Manufacturing Space by ID");
                System.Console.WriteLine("3) Create Manufacturing Space");
                System.Console.WriteLine("4) Delete Manufacturing Space by ID");
                System.Console.WriteLine("5) Exit to main menu");
                System.Console.Write("\r\nSelect an option: ");

                switch (System.Console.ReadLine()) {
                    case "1":
                        ListAllManufacturingSpaces(manufacturingSpaceService).Wait();
                        break;
                    case "2":
                        GetManufacturingSpaceById(manufacturingSpaceService).Wait();
                        break;
                    case "3":
                        CreateManufacturingSpace(manufacturingSpaceService).Wait();
                        break;
                    case "4":
                        DeleteManufacturingSpaceById(manufacturingSpaceService).Wait();
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

        private async Task ListAllManufacturingSpaces(IManufacturingSpaceService service) {
            var spaces = await service.GetAllAsync();
            System.Console.WriteLine("\nAll Manufacturing Spaces:");
            foreach (var space in spaces) {
                System.Console.WriteLine($"ID: {space.Id}, Code: {space.Code}, Description: {space.Description}, Area: {space.EquipmentArea}");
            }
        }

        private async Task GetManufacturingSpaceById(IManufacturingSpaceService service) {
            System.Console.Write("\nEnter Manufacturing Space ID: ");
            if (int.TryParse(System.Console.ReadLine(), out int id)) {
                var space = await service.GetByIdAsync(id);
                if (space != null) {
                    System.Console.WriteLine($"ID: {space.Id}, Code: {space.Code}, Description: {space.Description}, Area: {space.EquipmentArea}");
                }
                else {
                    System.Console.WriteLine("\nManufacturing Space not found.");
                }
            }
            else {
                System.Console.WriteLine("\nInvalid input, enter a numeric value.");
            }
        }

        private async Task CreateManufacturingSpace(IManufacturingSpaceService service) {
            var newSpace = new CreateManufacturingSpaceDto();

            System.Console.Write("\nEnter Manufacturing Space Code: ");
            newSpace.Code = System.Console.ReadLine();

            System.Console.Write("Enter Manufacturing Space Name: ");
            newSpace.Description = System.Console.ReadLine();

            System.Console.Write("Enter Manufacturing Space Area: ");
            if (double.TryParse(System.Console.ReadLine(), out double area)) {
                newSpace.EquipmentArea = area;
                await service.CreateAsync(newSpace);
                System.Console.WriteLine("\nManufacturing Space created successfully.");
            }
            else {
                System.Console.WriteLine("\nInvalid input, enter a numeric value for area.");
            }
        }

        private async Task DeleteManufacturingSpaceById(IManufacturingSpaceService service) {
            System.Console.Write("\nEnter Manufacturing Space ID to delete: ");
            if (int.TryParse(System.Console.ReadLine(), out int id)) {
                await service.DeleteAsync(id);
                System.Console.WriteLine("\nManufacturing Space deleted successfully.");
            }
            else {
                System.Console.WriteLine("\nInvalid input, enter a numeric value.");
            }
        }
    }
}
