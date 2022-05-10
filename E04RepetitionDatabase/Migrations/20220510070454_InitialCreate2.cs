using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E04RepetitionDatabase.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Text" },
                values: new object[] { new Guid("73c31f76-e39e-4248-9c18-66a08a5c62c9"), "Note 1" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Text" },
                values: new object[] { new Guid("73c31f76-e39e-4248-9c18-66a08a5c62d0"), "Note 2" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Text" },
                values: new object[] { new Guid("73c31f76-e39e-4248-9c18-66a08a5c62d1"), "Note 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("73c31f76-e39e-4248-9c18-66a08a5c62c9"));

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("73c31f76-e39e-4248-9c18-66a08a5c62d0"));

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: new Guid("73c31f76-e39e-4248-9c18-66a08a5c62d1"));
        }
    }
}
