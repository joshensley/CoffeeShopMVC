using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShopMVC.Data.Migrations
{
    public partial class AddOrderCartModelToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderCart",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ItemProductID = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCart", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderCart_ItemProducts_ItemProductID",
                        column: x => x.ItemProductID,
                        principalTable: "ItemProducts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderCart_ItemProductID",
                table: "OrderCart",
                column: "ItemProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderCart");
        }
    }
}
