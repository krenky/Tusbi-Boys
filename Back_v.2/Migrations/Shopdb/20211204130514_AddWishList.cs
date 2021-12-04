using Microsoft.EntityFrameworkCore.Migrations;

namespace Back_v._2.Migrations.Shopdb
{
    public partial class AddWishList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUserProduct",
                columns: table => new
                {
                    AspNetUsersWishListId = table.Column<string>(type: "text", nullable: false),
                    WishListId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserProduct", x => new { x.AspNetUsersWishListId, x.WishListId });
                    table.ForeignKey(
                        name: "FK_AspNetUserProduct_AspNetUsers_AspNetUsersWishListId",
                        column: x => x.AspNetUsersWishListId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserProduct_Products_WishListId",
                        column: x => x.WishListId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserProduct_WishListId",
                table: "AspNetUserProduct",
                column: "WishListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserProduct");
        }
    }
}
