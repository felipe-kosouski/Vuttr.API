using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vuttr.API.Domain.Models;

namespace Vuttr.API.Data.Configuration
{
    public class ToolConfiguration : IEntityTypeConfiguration<Tool>
    {
        public void Configure(EntityTypeBuilder<Tool> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasColumnType("text");
            builder.Property(x => x.Link).HasColumnType("text");
            builder.Property(x => x.Description).HasColumnType("text");
            builder.HasMany(x => x.ToolTags).WithOne(x => x.Tool);
            builder.Property(x => x.CreatedAt).HasColumnType("date");
            builder.Property(x => x.UpdatedAt).HasColumnType("date");
        }
    }
}