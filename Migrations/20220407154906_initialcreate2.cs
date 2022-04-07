using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackApi.Migrations
{
    public partial class initialcreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Developers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Developers",
                type: "TEXT",
                nullable: true);
        }
    }
}
