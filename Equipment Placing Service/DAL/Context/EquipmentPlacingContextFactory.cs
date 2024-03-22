using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Equipment_Placing_Service.DAL.Context {
    public class EquipmentPlacingContextFactory : IDesignTimeDbContextFactory<EquipmentPlacingContext> {
        public EquipmentPlacingContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<EquipmentPlacingContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=EquipmentPlacingDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new EquipmentPlacingContext(optionsBuilder.Options);
        }
    }
}
