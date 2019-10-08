using Microsoft.EntityFrameworkCore.Migrations;

namespace CV.Data.EF.Migrations
{
    public partial class addColCatBlogId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryBlogId",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryBlogId",
                table: "Posts");
        }
    }
}
