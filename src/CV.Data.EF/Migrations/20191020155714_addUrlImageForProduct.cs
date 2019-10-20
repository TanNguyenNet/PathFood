using Microsoft.EntityFrameworkCore.Migrations;

namespace CV.Data.EF.Migrations
{
    public partial class addUrlImageForProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "Products");
        }
    }
}
