using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShopMVC.Data.Migrations
{
    public partial class EditOrderCartGroupModelInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "OrderCart",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "OrderCartGroup",
                table: "OrderCart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCartGroup",
                table: "OrderCart");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserID",
                table: "OrderCart",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
