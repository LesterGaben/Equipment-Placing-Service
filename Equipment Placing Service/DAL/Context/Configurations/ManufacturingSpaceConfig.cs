using Equipment_Placing_Service.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipment_Placing_Service.DAL.Context.Configurations {
    public class ManufacturingSpaceConfig : IEntityTypeConfiguration<ManufacturingSpace> {
        public void Configure(EntityTypeBuilder<ManufacturingSpace> builder) {
            builder.HasKey(ms => ms.Id);
            builder.Property(ms => ms.Id)
               .ValueGeneratedOnAdd();
            builder.HasIndex(ms => ms.Code).IsUnique();
            builder.Property(ms => ms.Code).IsRequired().HasMaxLength(50);
            builder.Property(ms => ms.Description).IsRequired().HasMaxLength(2000);
            builder.Property(ms => ms.EquipmentArea).IsRequired();
        }
    }
}
