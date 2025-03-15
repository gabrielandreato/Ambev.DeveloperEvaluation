using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.SaleNumber).IsRequired().HasMaxLength(50);

        builder.Property(s => s.SaleDate).IsRequired();

        builder.Property(u => u.Customer)
            .HasConversion<string>()
            .HasMaxLength(30);

        builder.Property(u => u.Branch)
            .HasConversion<string>()
            .HasMaxLength(30);

        builder.Property(s => s.IsCancelled).IsRequired();

        builder.HasIndex(s => s.SaleNumber)
            .IsUnique();

        builder.HasMany(s => s.Items)
            .WithOne()
            .HasForeignKey(x => x.SaleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}