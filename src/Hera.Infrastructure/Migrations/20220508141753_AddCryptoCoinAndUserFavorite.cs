using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hera.Infrastructure.Migrations
{
    public partial class AddCryptoCoinAndUserFavorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptoCoins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketCapRanking = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentPrice = table.Column<double>(type: "float", nullable: true),
                    PercentChange7D = table.Column<double>(type: "float", nullable: true),
                    MarketCap = table.Column<long>(type: "bigint", nullable: true),
                    PercentChange24H = table.Column<double>(type: "float", nullable: true),
                    MaxSupply = table.Column<long>(type: "bigint", nullable: true),
                    CirculatingSupply = table.Column<long>(type: "bigint", nullable: true),
                    TotalSupply = table.Column<long>(type: "bigint", nullable: true),
                    Volume24h = table.Column<long>(type: "bigint", nullable: true),
                    CurrentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoCoins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CryptoCoinSymbol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoCoins");

            migrationBuilder.DropTable(
                name: "UserFavorites");
        }
    }
}
