using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vuttr.API.Domain.Models;

namespace Vuttr.API.Data.Configuration
{
    public class ToolConfiguration : IEntityTypeConfiguration<Tool>
    {
        public void Configure(EntityTypeBuilder<Tool> builder)
        {
            builder.HasData
            (
                new Tool
                {
                    Title = "Postgre SQL",
                    Description = "Database Tool",
                    Link = "http://postgres.com",
                    Tags = new []
                    {
                        "db",
                        "postgre",
                        "sql"
                    }

                },
                new Tool
                {
                    Title = "Insomnia",
                    Description = "Rest Client",
                    Link = "http://insomnia.com",
                    Tags = new []
                    {
                        "http",
                        "api",
                        "rest"
                    }
                }
            );
        }
    }
}