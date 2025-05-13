using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SalesItemConfiguration : IEntityTypeConfiguration<SalesItem>
{
    public void Configure(EntityTypeBuilder<SalesItem> builder)
    {
        builder.ToTable(nameof(SalesItem));
        
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(s => s.Quantity).IsRequired();
        
        builder.Property(s => s.SalesId).IsRequired();
        builder.HasOne(s => s.Sales)
            .WithMany(c => c.SalesItems)        
            .HasForeignKey(s => s.SalesId);
        
        builder.Property(s => s.ProductId).IsRequired();
        builder.HasOne(s => s.Product)
            .WithMany(c => c.SalesItems)        
            .HasForeignKey(s => s.SalesId);
        
        builder.Property(p => p.Discount).HasColumnType("decimal(10,2)").IsRequired();
    }
}