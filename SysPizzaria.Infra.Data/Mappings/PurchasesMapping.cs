using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysPizzaria.Domain.Entities;

namespace SysPizzaria.Infra.Data.Mappings
{
    public class PurchasesMapping : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Compra");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductId)
                .IsRequired()
                .HasColumnName("IdProduto");

            builder.Property(x => x.PersonId)
                .IsRequired()
                .HasColumnName("IdPessoa");

            builder.Property(x => x.Date)
                .IsRequired()
                .HasColumnName("DataCompra");

            /*builder.HasOne(x => x.Person)
                .WithMany(x => x.Purchases);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Purchases);*/

        }
    }
}