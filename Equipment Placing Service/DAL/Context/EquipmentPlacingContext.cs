using Equipment_Placing_Service.DAL.Context.Configurations;
using Equipment_Placing_Service.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Equipment_Placing_Service.DAL.Context {
    public class EquipmentPlacingContext(DbContextOptions<EquipmentPlacingContext> options) : DbContext(options) {
        public virtual DbSet<ManufacturingSpace> PManufacturingSpaces { get; set; }
        public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }
        public virtual DbSet<EquipmentPlacementContract> EquipmentPlacementContracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ManufacturingSpace).Assembly);
        }

    }
}
