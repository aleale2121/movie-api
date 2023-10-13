using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: false),
                    ReleaseYear = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Address", "Location", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Address 1", "Location 1", "Cinema 1", "Phone 1" },
                    { 2, "Address 2", "Location 2", "Cinema 2", "Phone 2" },
                    { 3, "Address 3", "Location 3", "Cinema 3", "Phone 3" },
                    { 4, "Address 4", "Location 4", "Cinema 4", "Phone 4" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Genre", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Genre 1", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Movie 1" },
                    { 2, "Genre 2", new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Movie 2" },
                    { 3, "Genre 3", new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Movie 3" },
                    { 4, "Genre 4", new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Movie 4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
