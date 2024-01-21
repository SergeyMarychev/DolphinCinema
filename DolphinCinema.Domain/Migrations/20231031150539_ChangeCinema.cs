using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DolphinCinema.Domain.Migrations
{
    public partial class ChangeCinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PathToImage",
                table: "Cinemas",
                newName: "Contacts");

            migrationBuilder.AddColumn<List<string>>(
                name: "Images",
                table: "Cinemas",
                type: "text[]",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Cinemas");

            migrationBuilder.RenameColumn(
                name: "Contacts",
                table: "Cinemas",
                newName: "PathToImage");
        }
    }
}
