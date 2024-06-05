using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerConnect.Infrastructure.Migrations
{
    public partial class Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Client",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Client",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Client",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Client",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Client",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Client");
        }
    }
}
