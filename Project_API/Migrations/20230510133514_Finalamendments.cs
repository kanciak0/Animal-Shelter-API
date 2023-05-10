using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_API.Migrations
{
    /// <inheritdoc />
    public partial class Finalamendments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "UserAnimals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "UserAnimals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Breed",
                table: "UserAnimals");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "UserAnimals");
        }
    }
}
