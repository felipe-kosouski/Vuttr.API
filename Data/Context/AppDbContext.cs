using Microsoft.EntityFrameworkCore;
using Vuttr.API.Data.Configuration;
using Vuttr.API.Domain.Models;

namespace Vuttr.API.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ToolConfiguration());
        }
        public DbSet<Tool> Tools { get; set; }
    }
}