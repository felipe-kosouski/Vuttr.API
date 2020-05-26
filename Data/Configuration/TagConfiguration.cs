using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vuttr.API.Domain.Models;

namespace Vuttr.API.Data.Configuration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasColumnType("text");
            builder.HasMany(x => x.ToolTags).WithOne(x => x.Tag);
            builder.Property(x => x.CreatedAt).HasColumnType("date");
            builder.Property(x => x.UpdatedAt).HasColumnType("date");
        }
    }
}