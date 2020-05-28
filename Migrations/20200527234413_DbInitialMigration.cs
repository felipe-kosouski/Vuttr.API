using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vuttr.API.Migrations
{
    public partial class DbInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Link = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Tags = table.Column<string[]>(type: "text[]", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "Id", "CreatedAt", "Description", "Link", "Tags", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a572ba3e-27e8-4029-95a5-3456ed3f8127"), new DateTime(2020, 5, 27, 20, 44, 12, 691, DateTimeKind.Local).AddTicks(9290), "Database Tool", "http://postgres.com", new[] { "DB", "Postgre", "SQL" }, "Postgre SQL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("532c40ef-5deb-4997-ac25-38a7bd78f712"), new DateTime(2020, 5, 27, 20, 44, 12, 692, DateTimeKind.Local).AddTicks(1100), "Rest Client", "http://insomnia.com", new[] { "HTTP", "Api", "REST" }, "Insomnia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tools");
        }
    }
}
