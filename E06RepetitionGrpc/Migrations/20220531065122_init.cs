using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E06RepetitionGrpc.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sws = table.Column<int>(type: "int", nullable: false),
                    Cp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Cp", "Name", "Sws" },
                values: new object[] { new Guid("73c31f76-e39e-4248-9c18-66a08a5c62c9"), 5, "MC1", 8 });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Cp", "Name", "Sws" },
                values: new object[] { new Guid("73c31f76-e39e-4248-9c18-66a08a5c62d0"), 5, "WE1", 8 });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Cp", "Name", "Sws" },
                values: new object[] { new Guid("73c31f76-e39e-4248-9c18-66a08a5c62d1"), 5, "VRAR", 8 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
