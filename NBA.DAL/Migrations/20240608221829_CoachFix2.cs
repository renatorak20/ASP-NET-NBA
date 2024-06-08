using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBA.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CoachFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Coaches_CoachID",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CoachID",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CoachID",
                table: "Teams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoachID",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 1,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 2,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 3,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 4,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 5,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 6,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 7,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 8,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 9,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 10,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 11,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 12,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 13,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 14,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 15,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 16,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 17,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 18,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 19,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 20,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 21,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 22,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 23,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 24,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 25,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 26,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 27,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 28,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 29,
                column: "CoachID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 30,
                column: "CoachID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CoachID",
                table: "Teams",
                column: "CoachID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Coaches_CoachID",
                table: "Teams",
                column: "CoachID",
                principalTable: "Coaches",
                principalColumn: "ID");
        }
    }
}
