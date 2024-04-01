using Equipment_Placing_Service.BLL.Services;
using Equipment_Placing_Service.BLL.Services.Interfaces;
using Equipment_Placing_Service.DAL.Context;
using Equipment_Placing_Service.DAL.Repositories;
using Equipment_Placing_Service.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Equipment_Placing_Service.BLL.MappingProfiles;
using System.Text;

namespace EquipmentPlacingService.Console {
    public class Program {
        static ServiceProvider serviceProvider;

        public static void Main(string[] args) {

            System.Console.OutputEncoding = Encoding.Unicode;
            System.Console.InputEncoding = Encoding.Unicode;

            SettingUpDI();

            bool showMenu = true;
            while (showMenu) {
                showMenu = MainMenu();
            }
        }

        static void SettingUpDI() {
            serviceProvider = new ServiceCollection()
                .AddDbContext<EquipmentPlacingContext>(options =>
                    options.UseSqlServer("Server=localhost;Database=EquipmentPlacingDB;Trusted_Connection=True;TrustServerCertificate=True;"))
                .AddScoped<IManufacturingSpaceRepository, ManufacturingSpaceRepository>()
                .AddScoped<IEquipmentTypeRepository, EquipmentTypeRepository>()
                .AddScoped<IEquipmentPlacementContractRepository, EquipmentPlacementContractRepository>()
                .AddScoped<IManufacturingSpaceService, ManufacturingSpaceService>()
                .AddScoped<IEquipmentTypeService, EquipmentTypeService>()
                .AddScoped<IEquipmentPlacementContractService, EquipmentPlacementContractService>()
                .AddAutoMapper(typeof(AutoMapperProfile))
                .BuildServiceProvider();
        }

        static bool MainMenu() {
            System.Console.WriteLine("Choose an option:");
            System.Console.WriteLine("1) Equipment Types");
            System.Console.WriteLine("2) Manufacturing Spaces");
            System.Console.WriteLine("3) Equipment Placement Contracts");
            System.Console.WriteLine("4) Exit");
            System.Console.Write("\r\nSelect an option: ");

            switch (System.Console.ReadLine()) {
                case "1":
                    var equipmentTypeMenu = new EquipmentTypeMenu(serviceProvider);
                    equipmentTypeMenu.ShowMenu();
                    return true;
                case "2":
                    var manufacturingSpaceMenu = new ManufacturingSpaceMenu(serviceProvider);
                    manufacturingSpaceMenu.ShowMenu();
                    return true;
                case "3":
                    var equipmentPlacementContractMenu = new EquipmentPlacementContractMenu(serviceProvider);
                    equipmentPlacementContractMenu.ShowMenu();
                    return true;
                case "4":
                    return false;
                default:
                    System.Console.WriteLine();
                    return true;
            }
        }
    }

    
}