using Microsoft.EntityFrameworkCore;
using petshop_management.Models;

namespace petshop_management.Data
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options)
        : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
    }
}