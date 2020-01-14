using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SouthSeaTrader.Server.Data.Migations
{
    public partial class TradeGoodsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    TradeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipName = table.Column<string>(nullable: true),
                    TradeDate = table.Column<DateTime>(nullable: false),
                    Profit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.TradeId);
                });

            migrationBuilder.CreateTable(
                name: "TradeGoods",
                columns: table => new
                {
                    TradeGoodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Recommendation = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    Instrument = table.Column<int>(nullable: false),
                    TradeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeGoods", x => x.TradeGoodId);
                    table.ForeignKey(
                        name: "FK_TradeGoods_Trades_TradeId",
                        column: x => x.TradeId,
                        principalTable: "Trades",
                        principalColumn: "TradeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TradeGoods_TradeId",
                table: "TradeGoods",
                column: "TradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradeGoods");

            migrationBuilder.DropTable(
                name: "Trades");
        }
    }
}
