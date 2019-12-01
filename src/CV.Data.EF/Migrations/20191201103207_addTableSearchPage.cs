using Microsoft.EntityFrameworkCore.Migrations;

namespace CV.Data.EF.Migrations
{
    public partial class addTableSearchPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchPages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Lang = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    ItemId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchPages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchPages");
        }
    }
}
