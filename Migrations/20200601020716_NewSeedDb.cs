using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vuttr.API.Migrations
{
    public partial class NewSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: new Guid("532c40ef-5deb-4997-ac25-38a7bd78f712"));

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: new Guid("a572ba3e-27e8-4029-95a5-3456ed3f8127"));

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "Id", "CreatedAt", "Description", "Link", "Tags", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9dc18a59-c736-4697-ac1c-fdc380292053"), new DateTime(2020, 5, 31, 23, 7, 15, 942, DateTimeKind.Local).AddTicks(7840), "Database Tool", "http://postgres.com", new[] { "db", "postgre", "sql" }, "Postgre SQL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5654a6e9-cb18-43fa-a95c-c959b9277267"), new DateTime(2020, 5, 31, 23, 7, 15, 942, DateTimeKind.Local).AddTicks(9700), "Rest Client", "http://insomnia.com", new[] { "http", "api", "rest" }, "Insomnia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: new Guid("5654a6e9-cb18-43fa-a95c-c959b9277267"));

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: new Guid("9dc18a59-c736-4697-ac1c-fdc380292053"));

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "Id", "CreatedAt", "Description", "Link", "Tags", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a572ba3e-27e8-4029-95a5-3456ed3f8127"), new DateTime(2020, 5, 27, 20, 44, 12, 691, DateTimeKind.Local).AddTicks(9290), "Database Tool", "http://postgres.com", new[] { "DB", "Postgre", "SQL" }, "Postgre SQL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("532c40ef-5deb-4997-ac25-38a7bd78f712"), new DateTime(2020, 5, 27, 20, 44, 12, 692, DateTimeKind.Local).AddTicks(1100), "Rest Client", "http://insomnia.com", new[] { "HTTP", "Api", "REST" }, "Insomnia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
