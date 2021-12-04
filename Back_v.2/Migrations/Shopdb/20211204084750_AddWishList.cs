using Microsoft.EntityFrameworkCore.Migrations;

namespace Back_v._2.Migrations.Shopdb
{
    public partial class AddWishList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AspNetUserId",
                table: "Products",
                column: "AspNetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_AspNetUserId",
                table: "Products",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_AspNetUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AspNetUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "Products");
        }
    }
}
