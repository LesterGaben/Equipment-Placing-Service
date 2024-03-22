using Equipment_Placing_Service.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipment_Placing_Service.DAL.Context.Configurations {
    public class EquipmentPlacementContractConfig : IEntityTypeConfiguration<EquipmentPlacementContract> {
        public void Configure(EntityTypeBuilder<EquipmentPlacementContract> builder) {
            builder.HasKey(epc => epc.Id);
            builder.Property(epc => epc.Id)
               .ValueGeneratedOnAdd();
            builder.HasOne(epc => epc.ManufacturingSpace)
                   .WithMany()
                   .HasForeignKey(epc => epc.ManufacturingSpaceId);
            builder.HasOne(epc => epc.EquipmentType)
                   .WithMany()
                   .HasForeignKey(epc => epc.EquipmentTypeId);
            builder.Property(epc => epc.Quantity).IsRequired();
        }
    }
}
