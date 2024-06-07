using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NBA.DAL.Migrations
{
    /// <inheritdoc />
    public partial class PlayerInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "ID", "CountryID", "DateOfBirth", "FirstName", "Height", "LastName", "PositionID", "TeamID", "Weight" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1963, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", 198, "Jordan", 2, 5, 98 },
                    { 2, null, new DateTime(1965, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scottie", 203, "Pippen", 3, 5, 102 },
                    { 3, null, new DateTime(1999, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luka", 201, "Dončić", 1, 7, 109 },
                    { 4, null, new DateTime(1978, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kobe", 198, "Bryant", 2, 14, 96 },
                    { 5, null, new DateTime(1984, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "LeBron", 206, "James", 3, 14, 113 },
                    { 7, null, new DateTime(1988, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Derrick", 190, "Rose", 1, 5, 89 },
                    { 8, null, new DateTime(1971, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Artūras", 203, "Karnišovas", 4, 5, 108 },
                    { 9, null, new DateTime(1978, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dirk", 213, "Nowitzki", 4, 7, 111 },
                    { 12, null, new DateTime(1959, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magic", 206, "Johnson", 1, 14, 100 },
                    { 13, null, new DateTime(1972, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shaquille", 216, "O'Neal", 5, 14, 147 },
                    { 33, null, new DateTime(1995, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nikola", 208, "Jokic", 5, 8, 113 },
                    { 34, null, new DateTime(1984, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carmelo", 203, "Anthony", 3, 8, 109 },
                    { 35, null, new DateTime(1961, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isiah", 185, "Thomas", 1, 9, 79 },
                    { 36, null, new DateTime(1957, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", 211, "Laimbeer", 5, 9, 111 },
                    { 37, null, new DateTime(1988, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stephen", 191, "Curry", 1, 10, 86 },
                    { 38, null, new DateTime(1990, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Klay", 201, "Thompson", 2, 10, 98 },
                    { 39, null, new DateTime(1963, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hakeem", 213, "Olajuwon", 5, 11, 115 },
                    { 40, null, new DateTime(1962, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clyde", 201, "Drexler", 2, 11, 95 },
                    { 41, null, new DateTime(1965, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reggie", 201, "Miller", 2, 12, 88 },
                    { 42, null, new DateTime(1978, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jermaine", 211, "O'Neal", 5, 12, 113 },
                    { 43, null, new DateTime(1985, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", 183, "Paul", 1, 13, 79 },
                    { 44, null, new DateTime(1989, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blake", 208, "Griffin", 4, 13, 113 },
                    { 47, null, new DateTime(1985, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marc", 216, "Gasol", 5, 15, 115 },
                    { 48, null, new DateTime(1987, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mike", 185, "Conley", 1, 15, 79 },
                    { 49, null, new DateTime(1982, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dwyane", 193, "Wade", 2, 16, 100 },
                    { 50, null, new DateTime(1972, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shaquille", 216, "O'Neal", 5, 16, 147 },
                    { 51, null, new DateTime(1947, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kareem", 218, "Abdul-Jabbar", 5, 17, 102 },
                    { 52, null, new DateTime(1938, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oscar", 196, "Robertson", 1, 17, 95 },
                    { 53, null, new DateTime(1976, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kevin", 211, "Garnett", 4, 18, 100 },
                    { 54, null, new DateTime(1988, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kevin", 208, "Love", 5, 18, 113 },
                    { 55, null, new DateTime(1993, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anthony", 211, "Davis", 5, 19, 115 },
                    { 56, null, new DateTime(1985, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", 183, "Paul", 1, 19, 79 },
                    { 57, null, new DateTime(1962, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patrick", 213, "Ewing", 5, 20, 109 },
                    { 58, null, new DateTime(1984, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carmelo", 203, "Anthony", 3, 20, 109 },
                    { 59, null, new DateTime(1988, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Russell", 191, "Westbrook", 1, 21, 90 },
                    { 60, null, new DateTime(1988, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kevin", 206, "Durant", 3, 21, 108 },
                    { 61, null, new DateTime(1972, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shaquille", 216, "O'Neal", 5, 22, 147 },
                    { 62, null, new DateTime(1985, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dwight", 211, "Howard", 5, 22, 120 },
                    { 63, null, new DateTime(1975, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allen", 183, "Iverson", 1, 23, 75 },
                    { 64, null, new DateTime(1950, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julius", 201, "Erving", 3, 23, 95 },
                    { 65, null, new DateTime(1963, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charles", 198, "Barkley", 4, 24, 114 },
                    { 66, null, new DateTime(1974, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steve", 190, "Nash", 1, 24, 82 },
                    { 67, null, new DateTime(1962, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clyde", 201, "Drexler", 2, 25, 95 },
                    { 68, null, new DateTime(1990, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Damian", 191, "Lillard", 1, 25, 88 },
                    { 69, null, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", 208, "Webber", 4, 26, 111 },
                    { 70, null, new DateTime(1990, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "DeMarcus", 211, "Cousins", 5, 26, 122 },
                    { 71, null, new DateTime(1976, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tim", 211, "Duncan", 4, 27, 113 },
                    { 72, null, new DateTime(1965, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", 216, "Robinson", 5, 27, 113 },
                    { 73, null, new DateTime(1977, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vince", 198, "Carter", 2, 28, 99 },
                    { 74, null, new DateTime(1984, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", 211, "Bosh", 4, 28, 110 },
                    { 75, null, new DateTime(1963, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karl", 206, "Malone", 4, 29, 113 },
                    { 76, null, new DateTime(1962, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", 185, "Stockton", 1, 29, 79 },
                    { 77, null, new DateTime(1963, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", 198, "Jordan", 2, 30, 98 },
                    { 78, null, new DateTime(1990, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", 193, "Wall", 1, 30, 95 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "ID",
                keyValue: 78);
        }
    }
}
