using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBA.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Team : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Coach");

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Coach",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamID",
                table: "Players",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Coach_TeamID",
                table: "Coach",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_Team_TeamID",
                table: "Coach",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Team_TeamID",
                table: "Players",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Team_TeamID",
                table: "Coach");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Team_TeamID",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamID",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Coach_TeamID",
                table: "Coach");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Coach");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Coach",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
