using Equipment_Placing_Service.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipment_Placing_Service.DAL.Context.Configurations {
    public class EquipmentTypeConfig : IEntityTypeConfiguration<EquipmentType> {
        public void Configure(EntityTypeBuilder<EquipmentType> builder) {
            builder.HasKey(et => et.Id);
            builder.Property(et => et.Id)
               .ValueGeneratedOnAdd();

            builder.HasIndex(et => et.Code).IsUnique();

            builder.Property(et => et.Code)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(et => et.Description)
               .IsRequired()
               .HasMaxLength(2000);

            builder.Property(et => et.Area)
               .IsRequired();
        }
    }
}
