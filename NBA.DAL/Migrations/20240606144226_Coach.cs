using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBA.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Coach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Countries_CountryID",
                table: "Coach");

            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Teams_TeamID",
                table: "Coach");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerAttachment_Players_PlayerID",
                table: "PlayerAttachment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerAttachment",
                table: "PlayerAttachment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coach",
                table: "Coach");

            migrationBuilder.RenameTable(
                name: "PlayerAttachment",
                newName: "PlayerAttachments");

            migrationBuilder.RenameTable(
                name: "Coach",
                newName: "Coaches");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerAttachment_PlayerID",
                table: "PlayerAttachments",
                newName: "IX_PlayerAttachments_PlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_Coach_TeamID",
                table: "Coaches",
                newName: "IX_Coaches_TeamID");

            migrationBuilder.RenameIndex(
                name: "IX_Coach_CountryID",
                table: "Coaches",
                newName: "IX_Coaches_CountryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerAttachments",
                table: "PlayerAttachments",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Countries_CountryID",
                table: "Coaches",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Teams_TeamID",
                table: "Coaches",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerAttachments_Players_PlayerID",
                table: "PlayerAttachments",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Countries_CountryID",
                table: "Coaches");

            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Teams_TeamID",
                table: "Coaches");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerAttachments_Players_PlayerID",
                table: "PlayerAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerAttachments",
                table: "PlayerAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches");

            migrationBuilder.RenameTable(
                name: "PlayerAttachments",
                newName: "PlayerAttachment");

            migrationBuilder.RenameTable(
                name: "Coaches",
                newName: "Coach");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerAttachments_PlayerID",
                table: "PlayerAttachment",
                newName: "IX_PlayerAttachment_PlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_Coaches_TeamID",
                table: "Coach",
                newName: "IX_Coach_TeamID");

            migrationBuilder.RenameIndex(
                name: "IX_Coaches_CountryID",
                table: "Coach",
                newName: "IX_Coach_CountryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerAttachment",
                table: "PlayerAttachment",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coach",
                table: "Coach",
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
                name: "FK_PlayerAttachment_Players_PlayerID",
                table: "PlayerAttachment",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
