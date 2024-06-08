using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NBA.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CoachInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Teams_TeamID",
                table: "Coaches");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Coaches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "ID", "CountryID", "DateOfBirth", "FirstName", "LastName", "TeamID" },
                values: new object[,]
                {
                    { 1, 186, new DateTime(1963, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phil", "Jackson", 14 },
                    { 2, 186, new DateTime(1963, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cool", "Coach", 7 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Teams_TeamID",
                table: "Coaches",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Teams_TeamID",
                table: "Coaches");

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Coaches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Teams_TeamID",
                table: "Coaches",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "ID");
        }
    }
}
