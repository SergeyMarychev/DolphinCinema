using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DolphinCinema.Domain.Migrations
{
    public partial class ChangeTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSold",
                table: "Tickets",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSold",
                table: "Tickets");
        }
    }
}
