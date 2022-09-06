using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AOP.WebAPI.Core.Data.Migrations
{
    public partial class RemoveIdFromHeadquartersMarket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeadquartersMarket_Markets_MarketId",
                table: "HeadquartersMarket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeadquartersMarket",
                table: "HeadquartersMarket");

            migrationBuilder.DropIndex(
                name: "IX_HeadquartersMarket_HeadquartersId",
                table: "HeadquartersMarket");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HeadquartersMarket");

            migrationBuilder.RenameColumn(
                name: "MarketId",
                table: "HeadquartersMarket",
                newName: "MarketsId");

            migrationBuilder.RenameIndex(
                name: "IX_HeadquartersMarket_MarketId",
                table: "HeadquartersMarket",
                newName: "IX_HeadquartersMarket_MarketsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeadquartersMarket",
                table: "HeadquartersMarket",
                columns: new[] { "HeadquartersId", "MarketsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HeadquartersMarket_Markets_MarketsId",
                table: "HeadquartersMarket",
                column: "MarketsId",
                principalTable: "Markets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeadquartersMarket_Markets_MarketsId",
                table: "HeadquartersMarket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeadquartersMarket",
                table: "HeadquartersMarket");

            migrationBuilder.RenameColumn(
                name: "MarketsId",
                table: "HeadquartersMarket",
                newName: "MarketId");

            migrationBuilder.RenameIndex(
                name: "IX_HeadquartersMarket_MarketsId",
                table: "HeadquartersMarket",
                newName: "IX_HeadquartersMarket_MarketId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HeadquartersMarket",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeadquartersMarket",
                table: "HeadquartersMarket",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HeadquartersMarket_HeadquartersId",
                table: "HeadquartersMarket",
                column: "HeadquartersId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeadquartersMarket_Markets_MarketId",
                table: "HeadquartersMarket",
                column: "MarketId",
                principalTable: "Markets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
