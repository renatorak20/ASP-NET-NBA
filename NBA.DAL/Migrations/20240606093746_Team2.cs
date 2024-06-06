using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBA.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Team2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Country_CountryID",
                table: "Coach");

            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Team_TeamID",
                table: "Coach");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Country_CountryID",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Position_PositionID",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Team_TeamID",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_Countries_CountryID",
                table: "Coach",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_Teams_TeamID",
                table: "Coach",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Countries_CountryID",
                table: "Players",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Positions_PositionID",
                table: "Players",
                column: "PositionID",
                principalTable: "Positions",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Countries_CountryID",
                table: "Coach");

            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Teams_TeamID",
                table: "Coach");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Countries_CountryID",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Positions_PositionID",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_Country_CountryID",
                table: "Coach",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_Team_TeamID",
                table: "Coach",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Country_CountryID",
                table: "Players",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Position_PositionID",
                table: "Players",
                column: "PositionID",
                principalTable: "Position",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Team_TeamID",
                table: "Players",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID");
        }
    }
}
