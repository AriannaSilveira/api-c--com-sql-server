using Microsoft.EntityFrameworkCore;
using petshop_management.Models;

namespace petshop_management.Data
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}