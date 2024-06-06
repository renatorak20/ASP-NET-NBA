using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NBA.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Team1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoachID",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConferenceID",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Conferences_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "ID", "Name", "TeamID" },
                values: new object[,]
                {
                    { 1, "Eastern Conference", 0 },
                    { 2, "Western Conference", 0 }
                });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 17,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 18,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 19,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 20,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 22,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 23,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 24,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 25,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 26,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 27,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 29,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "ID",
                keyValue: 30,
                columns: new[] { "CoachID", "ConferenceID" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CoachID",
                table: "Teams",
                column: "CoachID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ConferenceID",
                table: "Teams",
                column: "ConferenceID");

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_TeamID",
                table: "Conferences",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Coaches_CoachID",
                table: "Teams",
                column: "CoachID",
                principalTable: "Coaches",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Conferences_ConferenceID",
                table: "Teams",
                column: "ConferenceID",
                principalTable: "Conferences",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Coaches_CoachID",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Conferences_ConferenceID",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Conferences");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CoachID",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ConferenceID",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CoachID",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ConferenceID",
                table: "Teams");
        }
    }
}
