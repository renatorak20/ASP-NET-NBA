using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NBA.DAL.Migrations
{
    /// <inheritdoc />
    public partial class GameInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "ID", "AwayScore", "DateOfGame", "HomeScore", "TeamAwayID", "TeamHomeID", "VenueID" },
                values: new object[,]
                {
                    { 1, 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 125, 2, 7, 7 },
                    { 2, 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 3, 8, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
