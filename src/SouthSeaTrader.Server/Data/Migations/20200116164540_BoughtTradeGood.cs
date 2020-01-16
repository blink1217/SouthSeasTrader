using Microsoft.EntityFrameworkCore.Migrations;

namespace SouthSeaTrader.Server.Data.Migations
{
    public partial class BoughtTradeGood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Trades",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Bought",
                table: "TradeGoods",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "Bought",
                table: "TradeGoods");
        }
    }
}
