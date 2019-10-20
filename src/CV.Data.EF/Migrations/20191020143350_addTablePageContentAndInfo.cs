using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CV.Data.EF.Migrations
{
    public partial class addTablePageContentAndInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Infos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Lang = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Hotline = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Zalo = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PortEmail = table.Column<string>(nullable: true),
                    SmtpEmail = table.Column<string>(nullable: true),
                    InfoType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageContents",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Lang = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    URLImage = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Home = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageContents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Infos");

            migrationBuilder.DropTable(
                name: "PageContents");
        }
    }
}
