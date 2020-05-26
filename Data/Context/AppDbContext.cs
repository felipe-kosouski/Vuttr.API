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
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ToolConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new ToolTagConfiguration());
        }

        public DbSet<Tool> Tools { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ToolTag> ToolTags { get; set; }
    }
}