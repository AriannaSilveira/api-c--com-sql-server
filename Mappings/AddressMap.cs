using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using petshop_management.Models;
using petshop_management.Data;

namespace petshop_management.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(a => a.Street).IsRequired().HasMaxLength(255).HasColumnName("street");
            builder.Property(a => a.District).IsRequired().HasMaxLength(255).HasColumnName("district");
            builder.Property(a => a.City).IsRequired().HasMaxLength(255).HasColumnName("city");
            builder.Property(a => a.State).IsRequired().HasMaxLength(2).HasColumnName("state");

            builder.HasMany(a => a.Clients)
                .WithOne(c => c.Address)
                .HasForeignKey(c => c.AddressId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }

}

