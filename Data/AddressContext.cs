using Microsoft.EntityFrameworkCore;
using petshop_management.Models;

namespace petshop_management.Data
{
    public class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions<AddressContext> options)
        : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
    }
}