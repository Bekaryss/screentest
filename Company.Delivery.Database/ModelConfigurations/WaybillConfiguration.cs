using Company.Delivery.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Delivery.Database.ModelConfigurations;

internal class WaybillConfiguration : IEntityTypeConfiguration<Waybill>
{
    public void Configure(EntityTypeBuilder<Waybill> builder)
    {
        // TODO: все строковые свойства должны иметь ограничение на длину
        // TODO: должно быть ограничение на уникальность свойства Waybill.Number
        // TODO: ApplicationDbContextTests должен выполняться без ошибок

        builder.Property(w => w.Number)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasIndex(w => w.Number)
            .IsUnique();
        builder.HasMany(w => w.Items)
            .WithOne(c => c.Waybill)
            .HasForeignKey(c => c.WaybillId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}