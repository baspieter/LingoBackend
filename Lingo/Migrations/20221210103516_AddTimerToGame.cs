using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lingo.Migrations
{
    public partial class AddTimerToGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "green_balls",
                table: "game");

            migrationBuilder.RenameColumn(
                name: "red_balls",
                table: "game",
                newName: "timer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "timer",
                table: "game",
                newName: "red_balls");

            migrationBuilder.AddColumn<int>(
                name: "green_balls",
                table: "game",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
