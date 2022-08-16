using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Data.Migrations
{
    public partial class AddedUserReputation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reputation",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reputation",
                table: "AspNetUsers");
        }
    }
}
