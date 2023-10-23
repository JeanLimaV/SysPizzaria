using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using SysPizzaria.Domain.Entities;

namespace SysPizzaria.Infra.Data.Mappings
{
    public class PeopleMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Pessoa");
            
            builder.HasKey(c => c.Id);
                
            builder.Property(c => c.Document)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("Documento")
                .HasColumnType("VARCHAR(20)");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR(50)");

            builder.Property(c => c.Phone)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("Celular")
                .HasColumnType("VARCHAR(20)");

            builder.HasMany(c => c.Purchases)
                .WithOne(c => c.Person)
                .HasForeignKey(c => c.PersonId);
        }
    }
}