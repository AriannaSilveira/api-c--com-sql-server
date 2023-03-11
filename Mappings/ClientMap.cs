using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using petshop_management.Data;
using petshop_management.Models;

namespace petshop_management.Mappings
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(255).HasColumnName("name");
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100).HasColumnName("email");
            builder.Property(c => c.Phone).IsRequired().HasMaxLength(20).HasColumnName("phone");

            builder.HasOne(c => c.Address)
                .WithMany(a => a.Clients)
                .HasForeignKey(c => c.AddressId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            
           

            
        }
    }
}

