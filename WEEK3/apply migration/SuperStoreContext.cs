using Microsoft.EntityFrameworkCore;
using SuperStoreApp.Entities;

namespace SuperStoreApp.DataLayer
{
    public class SuperStoreContext : DbContext
    {
        public SuperStoreContext(DbContextOptions<SuperStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional model config here if needed
        }
    }
}

