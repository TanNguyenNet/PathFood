using Microsoft.EntityFrameworkCore.Migrations;

namespace CV.Data.EF.Migrations
{
    public partial class addActiveCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "CatalogSectors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "CatalogFunctions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "CatalogSectors");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "CatalogFunctions");
        }
    }
}
