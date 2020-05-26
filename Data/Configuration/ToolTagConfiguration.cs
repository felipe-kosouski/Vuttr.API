using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vuttr.API.Domain.Models;

namespace Vuttr.API.Data.Configuration
{
    public class ToolTagConfiguration : IEntityTypeConfiguration<ToolTag>
    {
        public void Configure(EntityTypeBuilder<ToolTag> builder)
        {
            builder.HasKey(x => new { x.ToolId, x.TagId});
            builder.HasOne(x => x.Tool).WithMany(x => x.ToolTags);
            builder.HasOne(x => x.Tag).WithMany(x => x.ToolTags);
        }
    }
}