using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SalesConfiguration : IEntityTypeConfiguration<Sales>
{
    public void Configure(EntityTypeBuilder<Sales> builder)
    {
        builder.ToTable(nameof(Sales));
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.Number).IsRequired();
        builder.Property(s => s.SalesAt)
            .IsRequired()
            .HasColumnType("timestamp")
            .HasDefaultValueSql("now()");
        
        builder.Property(s => s.BranchId).IsRequired();
        builder.HasOne(s => s.Branch)
            .WithMany(c => c.Sales)        
            .HasForeignKey(s => s.BranchId);
        
        builder.Property(p => p.TotalSales).HasColumnType("decimal(10,2)").IsRequired();
        builder.Property(p => p.Canceled).IsRequired();
    }
}