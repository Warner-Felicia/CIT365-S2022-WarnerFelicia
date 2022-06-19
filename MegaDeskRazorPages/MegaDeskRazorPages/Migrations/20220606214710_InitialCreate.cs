using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskRazorPages.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    width = table.Column<int>(type: "int", nullable: false),
                    depth = table.Column<int>(type: "int", nullable: false),
                    drawers = table.Column<int>(type: "int", nullable: false),
                    surfaceMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rushDays = table.Column<int>(type: "int", nullable: true),
                    quoteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    quoteTotal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desk", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desk");
        }
    }
}
