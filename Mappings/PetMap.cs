using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using petshop_management.Data;
using petshop_management.Models;

namespace petshop_management.Mappings
{
    public class PetMap : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("Pets");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(255).HasColumnName("name");
            builder.Property(c => c.Age).IsRequired().HasColumnName("age");

            builder.Property(c => c.Type).IsRequired().HasMaxLength(100).HasColumnName("type");
            builder.Property(c => c.Breed).IsRequired().HasMaxLength(100).HasColumnName("breed");

            builder.HasOne(p => p.Client)
                .WithMany(c => c.Pets)
                .HasForeignKey(p => p.ClientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

