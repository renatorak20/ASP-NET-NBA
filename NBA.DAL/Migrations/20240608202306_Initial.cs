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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "TeamAttachments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamAttachments", x => x.ID);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    TeamAttachmentID = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Teams_TeamAttachments_TeamAttachmentID",
                        column: x => x.TeamAttachmentID,
                        principalTable: "TeamAttachments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Teams_Venues_VenueID",
                        column: x => x.VenueID,
                        principalTable: "Venues",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamHomeID = table.Column<int>(type: "int", nullable: true),
                    TeamAwayID = table.Column<int>(type: "int", nullable: true),
                    VenueID = table.Column<int>(type: "int", nullable: true),
                    HomeScore = table.Column<int>(type: "int", nullable: false),
                    AwayScore = table.Column<int>(type: "int", nullable: false),
                    DateOfGame = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Games_Teams_TeamAwayID",
                        column: x => x.TeamAwayID,
                        principalTable: "Teams",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Games_Teams_TeamHomeID",
                        column: x => x.TeamHomeID,
                        principalTable: "Teams",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Games_Venues_VenueID",
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionID = table.Column<int>(type: "int", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                table: "TeamAttachments",
                columns: new[] { "ID", "Path" },
                values: new object[,]
                {
                    { 1, "/images/teams/1" },
                    { 2, "/images/teams/2" },
                    { 3, "/images/teams/3" },
                    { 4, "/images/teams/4" },
                    { 5, "/images/teams/5" },
                    { 6, "/images/teams/6" },
                    { 7, "/images/teams/7" },
                    { 8, "/images/teams/8" },
                    { 9, "/images/teams/9" },
                    { 10, "/images/teams/10" },
                    { 11, "/images/teams/11" },
                    { 12, "/images/teams/12" },
                    { 13, "/images/teams/13" },
                    { 14, "/images/teams/14" },
                    { 15, "/images/teams/15" },
                    { 16, "/images/teams/16" },
                    { 17, "/images/teams/17" },
                    { 18, "/images/teams/18" },
                    { 19, "/images/teams/19" },
                    { 20, "/images/teams/20" },
                    { 21, "/images/teams/21" },
                    { 22, "/images/teams/22" },
                    { 23, "/images/teams/23" },
                    { 24, "/images/teams/24" },
                    { 25, "/images/teams/25" },
                    { 26, "/images/teams/26" },
                    { 27, "/images/teams/27" },
                    { 28, "/images/teams/28" },
                    { 29, "/images/teams/29" },
                    { 30, "/images/teams/30" }
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
                columns: new[] { "ID", "CoachID", "ConferenceID", "Name", "TeamAttachmentID", "VenueID" },
                values: new object[,]
                {
                    { 1, null, 1, "Atlanta Hawks", 1, 1 },
                    { 2, null, 1, "Boston Celtics", 2, 2 },
                    { 3, null, 1, "Brooklyn Nets", 3, 3 },
                    { 4, null, 1, "Charlotte Hornets", 4, 4 },
                    { 5, null, 1, "Chicago Bulls", 5, 5 },
                    { 6, null, 1, "Cleveland Cavaliers", 6, 6 },
                    { 7, null, 2, "Dallas Mavericks", 7, 7 },
                    { 8, null, 2, "Denver Nuggets", 8, 8 },
                    { 9, null, 1, "Detroit Pistons", 9, 9 },
                    { 10, null, 2, "Golden State Warriors", 10, 10 },
                    { 11, null, 2, "Houston Rockets", 11, 11 },
                    { 12, null, 1, "Indiana Pacers", 12, 12 },
                    { 13, null, 2, "Los Angeles Clippers", 13, 13 },
                    { 14, null, 2, "Los Angeles Lakers", 14, 14 },
                    { 15, null, 2, "Memphis Grizzlies", 15, 15 },
                    { 16, null, 1, "Miami Heat", 16, 16 },
                    { 17, null, 1, "Milwaukee Bucks", 17, 17 },
                    { 18, null, 2, "Minnesota Timberwolves", 18, 18 },
                    { 19, null, 2, "New Orleans Pelicans", 19, 19 },
                    { 20, null, 1, "New York Knicks", 20, 20 },
                    { 21, null, 2, "Oklahoma City Thunder", 21, 21 },
                    { 22, null, 1, "Orlando Magic", 22, 22 },
                    { 23, null, 1, "Philadelphia 76ers", 23, 23 },
                    { 24, null, 2, "Phoenix Suns", 24, 24 },
                    { 25, null, 2, "Portland Trail Blazers", 25, 25 },
                    { 26, null, 2, "Sacramento Kings", 26, 26 },
                    { 27, null, 2, "San Antonio Spurs", 27, 27 },
                    { 28, null, 1, "Toronto Raptors", 28, 28 },
                    { 29, null, 2, "Utah Jazz", 29, 29 },
                    { 30, null, 1, "Washington Wizards", 30, 30 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "ID", "CountryID", "DateOfBirth", "FirstName", "Height", "LastName", "PositionID", "TeamID", "Weight" },
                values: new object[,]
                {
                    { 1, 186, new DateTime(1963, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", 198, "Jordan", 2, 5, 98 },
                    { 2, 186, new DateTime(1965, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scottie", 203, "Pippen", 3, 5, 102 },
                    { 3, 186, new DateTime(1988, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Derrick", 190, "Rose", 1, 5, 89 },
                    { 4, 101, new DateTime(1971, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Artūras", 203, "Karnišovas", 4, 5, 108 },
                    { 5, 158, new DateTime(1999, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luka", 201, "Dončić", 1, 7, 109 },
                    { 6, 64, new DateTime(1978, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dirk", 213, "Nowitzki", 4, 7, 111 },
                    { 7, 186, new DateTime(1978, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kobe", 198, "Bryant", 2, 14, 96 },
                    { 8, 186, new DateTime(1984, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "LeBron", 206, "James", 3, 14, 113 },
                    { 9, 186, new DateTime(1959, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magic", 206, "Johnson", 1, 14, 100 },
                    { 10, 186, new DateTime(1972, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shaquille", 216, "O'Neal", 5, 14, 147 },
                    { 11, 153, new DateTime(1995, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nikola", 208, "Jokic", 5, 8, 113 },
                    { 12, 186, new DateTime(1984, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carmelo", 203, "Anthony", 3, 8, 109 }
                });

            migrationBuilder.InsertData(
                table: "PlayerAttachments",
                columns: new[] { "ID", "Path", "PlayerID" },
                values: new object[,]
                {
                    { 1, "/uploads/photos/players/michael-jordan", 1 },
                    { 2, "/uploads/photos/players/scottie-pippen", 2 },
                    { 3, "/uploads/photos/players/derrick-rose", 3 },
                    { 4, "/uploads/photos/players/arturas-karnisovas", 4 },
                    { 5, "/uploads/photos/players/luka-doncic", 5 },
                    { 6, "/uploads/photos/players/dirk-nowitzki", 6 },
                    { 7, "/uploads/photos/players/kobe-bryant", 7 },
                    { 8, "/uploads/photos/players/lebron-james", 8 },
                    { 9, "/uploads/photos/players/magic-johnson", 9 },
                    { 10, "/uploads/photos/players/shaquille-oneal", 10 },
                    { 11, "/uploads/photos/players/nikola-jokic", 11 },
                    { 12, "/uploads/photos/players/carmelo-anthony", 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_CountryID",
                table: "Coaches",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_TeamID",
                table: "Coaches",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_TeamAwayID",
                table: "Games",
                column: "TeamAwayID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_TeamHomeID",
                table: "Games",
                column: "TeamHomeID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_VenueID",
                table: "Games",
                column: "VenueID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerAttachments_PlayerID",
                table: "PlayerAttachments",
                column: "PlayerID",
                unique: true);

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
                name: "IX_Teams_TeamAttachmentID",
                table: "Teams",
                column: "TeamAttachmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_VenueID",
                table: "Teams",
                column: "VenueID",
                unique: true,
                filter: "[VenueID] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "PlayerAttachments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
                name: "TeamAttachments");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
