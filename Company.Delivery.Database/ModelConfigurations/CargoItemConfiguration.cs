using Company.Delivery.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Delivery.Database.ModelConfigurations;

internal class CargoItemConfiguration : IEntityTypeConfiguration<CargoItem>
{
    public void Configure(EntityTypeBuilder<CargoItem> builder)
    {
        // TODO: все строковые свойства должны иметь ограничение на длину
        // TODO: должно быть ограничение на уникальность свойства CargoItem.Number в пределах одной сущности Waybill
        // TODO: ApplicationDbContextTests должен выполняться без ошибок

        builder.Property(c => c.Number)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.HasIndex(c => new { c.WaybillId, c.Number })
            .IsUnique();
        builder.HasOne(c => c.Waybill)
            .WithMany(w => w.Items)
            .HasForeignKey(c => c.WaybillId);
    }
}