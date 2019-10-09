using Microsoft.EntityFrameworkCore.Migrations;

namespace CV.Data.EF.Migrations
{
    public partial class addColSlugTableGroupQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "GroupQuestions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "GroupQuestions");
        }
    }
}
