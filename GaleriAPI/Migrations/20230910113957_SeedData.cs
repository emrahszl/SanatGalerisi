using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GaleriAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tablolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ressam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResminYapilmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tablolar", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tablolar",
                columns: new[] { "Id", "ResminYapilmaTarihi", "Ressam" },
                values: new object[,]
                {
                    { 1, new DateTime(1950, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pablo Picasso" },
                    { 2, new DateTime(1496, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leonardo da Vinci" },
                    { 3, new DateTime(1972, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salvador Dali" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tablolar");
        }
    }
}
