using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_API.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_Animal_Shelter1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnimalsID_Users_User_ID",
                table: "UserAnimalsID");

            migrationBuilder.RenameColumn(
                name: "User_ID",
                table: "UserAnimalsID",
                newName: "Animal_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnimalsID_Users_Animal_ID",
                table: "UserAnimalsID",
                column: "Animal_ID",
                principalTable: "Users",
                principalColumn: "User_UUID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnimalsID_Users_Animal_ID",
                table: "UserAnimalsID");

            migrationBuilder.RenameColumn(
                name: "Animal_ID",
                table: "UserAnimalsID",
                newName: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnimalsID_Users_User_ID",
                table: "UserAnimalsID",
                column: "User_ID",
                principalTable: "Users",
                principalColumn: "User_UUID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
