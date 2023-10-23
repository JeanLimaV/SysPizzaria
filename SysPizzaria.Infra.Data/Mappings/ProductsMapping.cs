using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysPizzaria.Domain.Entities;

namespace SysPizzaria.Infra.Data.Mappings
{
    public class ProductsMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.CodERP)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("CodErp")
                .HasColumnType("VARCHAR(10)");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR(100)");

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnName("Preco")
                .HasColumnType("DECIMAL(10,2)");

            builder.HasMany(p => p.Purchases)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);
        }
    }
}