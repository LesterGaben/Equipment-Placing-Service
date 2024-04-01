using Equipment_Placing_Service.BLL.DTOs;
using Equipment_Placing_Service.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EquipmentPlacingService.Console {
    public class EquipmentPlacementContractMenu(IServiceProvider serviceProvider) {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public void ShowMenu() {
            var contractService = _serviceProvider.GetService<IEquipmentPlacementContractService>();
            var manufacturingSpaceService = _serviceProvider.GetService<IManufacturingSpaceService>();

            bool showMenu = true;
            while (showMenu) {
                System.Console.WriteLine("\nChoose an option for Equipment Placement Contracts:");
                System.Console.WriteLine("1) List all Contracts");
                System.Console.WriteLine("2) Get Contract by Number");
                System.Console.WriteLine("3) Create Contract");
                System.Console.WriteLine("4) Delete Contract by ID");
                System.Console.WriteLine("5) Exit to main menu");
                System.Console.Write("\r\nSelect an option: ");

                switch (System.Console.ReadLine()) {


                    case "1":
                        ListAllContracts(contractService).Wait();
                        break;
                    case "2":
                        GetContractById(contractService).Wait();
                        break;
                    case "3":
                        try {
                            CreateContract(contractService, manufacturingSpaceService).Wait();
                        }
                        catch (Exception error) {
                            if (error.Message.Contains("Insufficient space for the equipment."))
                                System.Console.WriteLine("Insufficient space for the equipment.");
                            else 
                                System.Console.WriteLine(error.Message);
                        }
                        break;
                    case "4":
                        DeleteContractById(contractService).Wait();
                        break;
                    case "5":
                        showMenu = false;
                        break;
                    default:
                        System.Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }

        private async Task ListAllContracts(IEquipmentPlacementContractService service) {
            var contracts = await service.GetAllAsync();
            System.Console.WriteLine("\nAll Equipment Placement Contracts:");
            foreach (var contract in contracts) {
                System.Console.WriteLine($"ContractNumber: {contract.Id}, ManufacturingSpaceName: {contract.ManufacturingSpaceName}, EquipmentTypeName: {contract.EquipmentTypeName}, Quantity: {contract.Quantity}");
            }
        }

        private async Task GetContractById(IEquipmentPlacementContractService service) {
            System.Console.Write("\nEnter Contract Number: ");
            if (int.TryParse(System.Console.ReadLine(), out int id)) {
                var contract = await service.GetByIdAsync(id);
                if (contract != null) {
                    System.Console.WriteLine($"Number: {contract.Id}, ManufacturingSpaceName: {contract.ManufacturingSpaceName}, EquipmentTypeName: {contract.EquipmentTypeName}, Quantity: {contract.Quantity}");
                }
                else {
                    System.Console.WriteLine("\nContract not found.");
                }
            }
            else {
                System.Console.WriteLine("\nInvalid input, enter a numeric value.");
            }
        }

        private async Task CreateContract(IEquipmentPlacementContractService contractService, IManufacturingSpaceService spaceService) {
            var newContract = new CreateEquipmentPlacementContractDto();

            System.Console.Write("\nEnter Manufacturing Space Code: ");
            newContract.ManufacturingSpaceCode = System.Console.ReadLine();

            System.Console.Write("Enter Equipment Type Code: ");
            newContract.EquipmentTypeCode = System.Console.ReadLine();

            System.Console.Write("Enter Quantity: ");
            newContract.Quantity = int.Parse(System.Console.ReadLine());

            // Перевірка доступної площі
            var space = await spaceService.GetByCodeAsync(newContract.ManufacturingSpaceCode);
            if (space == null) {
                System.Console.WriteLine("\nManufacturing space not found.");
                return;
            }

            if (newContract.Quantity > space.EquipmentArea) {
                System.Console.WriteLine("\nInsufficient space in the manufacturing area.");
                return;
            }

            await contractService.CreateAsync(newContract);
            System.Console.WriteLine("\nEquipment Placement Contract created successfully.");
        }

        private async Task DeleteContractById(IEquipmentPlacementContractService service) {
            System.Console.Write("\nEnter Contract Number to delete: ");
            if (int.TryParse(System.Console.ReadLine(), out int id)) {
                await service.DeleteAsync(id);
                System.Console.WriteLine("\nContract deleted successfully.");
            }
            else {
                System.Console.WriteLine("\nInvalid input, enter a numeric value.");
            }
        }
    }
}
