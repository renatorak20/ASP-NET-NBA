using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NBA.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: true),
                    TeamID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Coaches_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VenueID = table.Column<int>(type: "int", nullable: true),
                    ConferenceID = table.Column<int>(type: "int", nullable: true),
                    CoachID = table.Column<int>(type: "int", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teams_Coaches_CoachID",
                        column: x => x.CoachID,
                        principalTable: "Coaches",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Teams_Conferences_ConferenceID",
                        column: x => x.ConferenceID,
                        principalTable: "Conferences",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Teams_Venues_VenueID",
                        column: x => x.VenueID,
                        principalTable: "Venues",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PositionID = table.Column<int>(type: "int", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: true),
                    TeamID = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Players_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Players_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PlayerAttachments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerID = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerAttachments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlayerAttachments_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Eastern Conference" },
                    { 2, "Western Conference" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Afghanistan" },
                    { 2, "Albania" },
                    { 3, "Algeria" },
                    { 4, "Andorra" },
                    { 5, "Angola" },
                    { 6, "Antigua and Barbuda" },
                    { 7, "Argentina" },
                    { 8, "Armenia" },
                    { 9, "Australia" },
                    { 10, "Austria" },
                    { 11, "Azerbaijan" },
                    { 12, "Bahamas" },
                    { 13, "Bahrain" },
                    { 14, "Bangladesh" },
                    { 15, "Barbados" },
                    { 16, "Belarus" },
                    { 17, "Belgium" },
                    { 18, "Belize" },
                    { 19, "Benin" },
                    { 20, "Bhutan" },
                    { 21, "Bolivia" },
                    { 22, "Bosnia and Herzegovina" },
                    { 23, "Botswana" },
                    { 24, "Brazil" },
                    { 25, "Brunei" },
                    { 26, "Bulgaria" },
                    { 27, "Burkina Faso" },
                    { 28, "Burundi" },
                    { 29, "Cabo Verde" },
                    { 30, "Cambodia" },
                    { 31, "Cameroon" },
                    { 32, "Canada" },
                    { 33, "Central African Republic" },
                    { 34, "Chad" },
                    { 35, "Chile" },
                    { 36, "China" },
                    { 37, "Colombia" },
                    { 38, "Comoros" },
                    { 39, "Congo, Democratic Republic of the" },
                    { 40, "Congo, Republic of the" },
                    { 41, "Costa Rica" },
                    { 42, "Croatia" },
                    { 43, "Cuba" },
                    { 44, "Cyprus" },
                    { 45, "Czech Republic" },
                    { 46, "Denmark" },
                    { 47, "Djibouti" },
                    { 48, "Dominica" },
                    { 49, "Dominican Republic" },
                    { 50, "Ecuador" },
                    { 51, "Egypt" },
                    { 52, "El Salvador" },
                    { 53, "Equatorial Guinea" },
                    { 54, "Eritrea" },
                    { 55, "Estonia" },
                    { 56, "Eswatini" },
                    { 57, "Ethiopia" },
                    { 58, "Fiji" },
                    { 59, "Finland" },
                    { 60, "France" },
                    { 61, "Gabon" },
                    { 62, "Gambia" },
                    { 63, "Georgia" },
                    { 64, "Germany" },
                    { 65, "Ghana" },
                    { 66, "Greece" },
                    { 67, "Grenada" },
                    { 68, "Guatemala" },
                    { 69, "Guinea" },
                    { 70, "Guinea-Bissau" },
                    { 71, "Guyana" },
                    { 72, "Haiti" },
                    { 73, "Honduras" },
                    { 74, "Hungary" },
                    { 75, "Iceland" },
                    { 76, "India" },
                    { 77, "Indonesia" },
                    { 78, "Iran" },
                    { 79, "Iraq" },
                    { 80, "Ireland" },
                    { 81, "Israel" },
                    { 82, "Italy" },
                    { 83, "Jamaica" },
                    { 84, "Japan" },
                    { 85, "Jordan" },
                    { 86, "Kazakhstan" },
                    { 87, "Kenya" },
                    { 88, "Kiribati" },
                    { 89, "Korea, North" },
                    { 90, "Korea, South" },
                    { 91, "Kosovo" },
                    { 92, "Kuwait" },
                    { 93, "Kyrgyzstan" },
                    { 94, "Laos" },
                    { 95, "Latvia" },
                    { 96, "Lebanon" },
                    { 97, "Lesotho" },
                    { 98, "Liberia" },
                    { 99, "Libya" },
                    { 100, "Liechtenstein" },
                    { 101, "Lithuania" },
                    { 102, "Luxembourg" },
                    { 103, "Madagascar" },
                    { 104, "Malawi" },
                    { 105, "Malaysia" },
                    { 106, "Maldives" },
                    { 107, "Mali" },
                    { 108, "Malta" },
                    { 109, "Marshall Islands" },
                    { 110, "Mauritania" },
                    { 111, "Mauritius" },
                    { 112, "Mexico" },
                    { 113, "Micronesia" },
                    { 114, "Moldova" },
                    { 115, "Monaco" },
                    { 116, "Mongolia" },
                    { 117, "Montenegro" },
                    { 118, "Morocco" },
                    { 119, "Mozambique" },
                    { 120, "Myanmar" },
                    { 121, "Namibia" },
                    { 122, "Nauru" },
                    { 123, "Nepal" },
                    { 124, "Netherlands" },
                    { 125, "New Zealand" },
                    { 126, "Nicaragua" },
                    { 127, "Niger" },
                    { 128, "Nigeria" },
                    { 129, "North Macedonia" },
                    { 130, "Norway" },
                    { 131, "Oman" },
                    { 132, "Pakistan" },
                    { 133, "Palau" },
                    { 134, "Panama" },
                    { 135, "Papua New Guinea" },
                    { 136, "Paraguay" },
                    { 137, "Peru" },
                    { 138, "Philippines" },
                    { 139, "Poland" },
                    { 140, "Portugal" },
                    { 141, "Qatar" },
                    { 142, "Romania" },
                    { 143, "Russia" },
                    { 144, "Rwanda" },
                    { 145, "Saint Kitts and Nevis" },
                    { 146, "Saint Lucia" },
                    { 147, "Saint Vincent and the Grenadines" },
                    { 148, "Samoa" },
                    { 149, "San Marino" },
                    { 150, "Sao Tome and Principe" },
                    { 151, "Saudi Arabia" },
                    { 152, "Senegal" },
                    { 153, "Serbia" },
                    { 154, "Seychelles" },
                    { 155, "Sierra Leone" },
                    { 156, "Singapore" },
                    { 157, "Slovakia" },
                    { 158, "Slovenia" },
                    { 159, "Solomon Islands" },
                    { 160, "Somalia" },
                    { 161, "South Africa" },
                    { 162, "South Sudan" },
                    { 163, "Spain" },
                    { 164, "Sri Lanka" },
                    { 165, "Sudan" },
                    { 166, "Suriname" },
                    { 167, "Sweden" },
                    { 168, "Switzerland" },
                    { 169, "Syria" },
                    { 170, "Taiwan" },
                    { 171, "Tajikistan" },
                    { 172, "Tanzania" },
                    { 173, "Thailand" },
                    { 174, "Timor-Leste" },
                    { 175, "Togo" },
                    { 176, "Tonga" },
                    { 177, "Trinidad and Tobago" },
                    { 178, "Tunisia" },
                    { 179, "Turkey" },
                    { 180, "Turkmenistan" },
                    { 181, "Tuvalu" },
                    { 182, "Uganda" },
                    { 183, "Ukraine" },
                    { 184, "United Arab Emirates" },
                    { 185, "United Kingdom" },
                    { 186, "United States" },
                    { 187, "Uruguay" },
                    { 188, "Uzbekistan" },
                    { 189, "Vanuatu" },
                    { 190, "Vatican City" },
                    { 191, "Venezuela" },
                    { 192, "Vietnam" },
                    { 193, "Yemen" },
                    { 194, "Zambia" },
                    { 195, "Zimbabwe" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Point Guard (PG)" },
                    { 2, "Shooting Guard (SG)" },
                    { 3, "Small Forward (SF)" },
                    { 4, "Power Forward (PF)" },
                    { 5, "Center (C)" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "ID", "City", "Name" },
                values: new object[,]
                {
                    { 1, "Atlanta", "State Farm Arena" },
                    { 2, "Boston", "TD Garden" },
                    { 3, "Brooklyn", "Barclays Center" },
                    { 4, "Charlotte", "Spectrum Center" },
                    { 5, "Chicago", "United Center" },
                    { 6, "Cleveland", "Rocket Mortgage FieldHouse" },
                    { 7, "Dallas", "American Airlines Center" },
                    { 8, "Denver", "Ball Arena" },
                    { 9, "Detroit", "Little Caesars Arena" },
                    { 10, "San Francisco", "Chase Center" },
                    { 11, "Houston", "Toyota Center" },
                    { 12, "Indianapolis", "Gainbridge Fieldhouse" },
                    { 13, "Los Angeles", "Crypto.com Arena" },
                    { 14, "Los Angeles", "Crypto.com Arena" },
                    { 15, "Memphis", "FedExForum" },
                    { 16, "Miami", "Kaseya Center" },
                    { 17, "Milwaukee", "Fiserv Forum" },
                    { 18, "Minneapolis", "Target Center" },
                    { 19, "New Orleans", "Smoothie King Center" },
                    { 20, "New York", "Madison Square Garden" },
                    { 21, "Oklahoma City", "Paycom Center" },
                    { 22, "Orlando", "Amway Center" },
                    { 23, "Philadelphia", "Wells Fargo Center" },
                    { 24, "Phoenix", "Footprint Center" },
                    { 25, "Portland", "Moda Center" },
                    { 26, "Sacramento", "Golden 1 Center" },
                    { 27, "San Antonio", "AT&T Center" },
                    { 28, "Toronto", "Scotiabank Arena" },
                    { 29, "Salt Lake City", "Vivint Arena" },
                    { 30, "Washington, D.C.", "Capital One Arena" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "ID", "CoachID", "ConferenceID", "Name", "Path", "VenueID" },
                values: new object[,]
                {
                    { 1, null, 1, "Atlanta Hawks", "/images/teams/1.png", 1 },
                    { 2, null, 1, "Boston Celtics", "/images/teams/2.png", 2 },
                    { 3, null, 1, "Brooklyn Nets", "/images/teams/3.png", 3 },
                    { 4, null, 1, "Charlotte Hornets", "/images/teams/4.png", 4 },
                    { 5, null, 1, "Chicago Bulls", "/images/teams/5.png", 5 },
                    { 6, null, 1, "Cleveland Cavaliers", "/images/teams/6.png", 6 },
                    { 7, null, 2, "Dallas Mavericks", "/images/teams/7.png", 7 },
                    { 8, null, 2, "Denver Nuggets", "/images/teams/8.png", 8 },
                    { 9, null, 1, "Detroit Pistons", "/images/teams/9.png", 9 },
                    { 10, null, 2, "Golden State Warriors", "/images/teams/10.png", 10 },
                    { 11, null, 2, "Houston Rockets", "/images/teams/11.png", 11 },
                    { 12, null, 1, "Indiana Pacers", "/images/teams/12.png", 12 },
                    { 13, null, 2, "Los Angeles Clippers", "/images/teams/13.png", 13 },
                    { 14, null, 2, "Los Angeles Lakers", "/images/teams/14.png", 14 },
                    { 15, null, 2, "Memphis Grizzlies", "/images/teams/15.png", 15 },
                    { 16, null, 1, "Miami Heat", "/images/teams/16.png", 16 },
                    { 17, null, 1, "Milwaukee Bucks", "/images/teams/17.png", 17 },
                    { 18, null, 2, "Minnesota Timberwolves", "/images/teams/18.png", 18 },
                    { 19, null, 2, "New Orleans Pelicans", "/images/teams/19.png", 19 },
                    { 20, null, 1, "New York Knicks", "/images/teams/20.png", 20 },
                    { 21, null, 2, "Oklahoma City Thunder", "/images/teams/21.png", 21 },
                    { 22, null, 1, "Orlando Magic", "/images/teams/22.png", 22 },
                    { 23, null, 1, "Philadelphia 76ers", "/images/teams/23.png", 23 },
                    { 24, null, 2, "Phoenix Suns", "/images/teams/24.png", 24 },
                    { 25, null, 2, "Portland Trail Blazers", "/images/teams/25.png", 25 },
                    { 26, null, 2, "Sacramento Kings", "/images/teams/26.png", 26 },
                    { 27, null, 2, "San Antonio Spurs", "/images/teams/27.png", 27 },
                    { 28, null, 1, "Toronto Raptors", "/images/teams/28.png", 28 },
                    { 29, null, 2, "Utah Jazz", "/images/teams/29.png", 29 },
                    { 30, null, 1, "Washington Wizards", "/images/teams/30.png", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_CountryID",
                table: "Coaches",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_TeamID",
                table: "Coaches",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerAttachments_PlayerID",
                table: "PlayerAttachments",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CountryID",
                table: "Players",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PositionID",
                table: "Players",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamID",
                table: "Players",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CoachID",
                table: "Teams",
                column: "CoachID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ConferenceID",
                table: "Teams",
                column: "ConferenceID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_VenueID",
                table: "Teams",
                column: "VenueID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Teams_TeamID",
                table: "Coaches",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "ID");
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

            migrationBuilder.DropTable(
                name: "PlayerAttachments");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Conferences");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
