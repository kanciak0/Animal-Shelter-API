using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_API.Migrations
{
    /// <inheritdoc />
    public partial class User_Responsibility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnimalsIDs_Users_UserId",
                table: "UserAnimalsIDs");

            migrationBuilder.DropIndex(
                name: "IX_UserAnimalsIDs_UserId",
                table: "UserAnimalsIDs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserAnimalsIDs");

            migrationBuilder.AddColumn<string>(
                name: "_Responsibility",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "User_UUID",
                table: "UserAnimalsIDs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "_Responsibility",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimalsIDs_User_UUID",
                table: "UserAnimalsIDs",
                column: "User_UUID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnimalsIDs_Users_User_UUID",
                table: "UserAnimalsIDs",
                column: "User_UUID",
                principalTable: "Users",
                principalColumn: "User_UUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnimalsIDs_Users_User_UUID",
                table: "UserAnimalsIDs");

            migrationBuilder.DropIndex(
                name: "IX_UserAnimalsIDs_User_UUID",
                table: "UserAnimalsIDs");

            migrationBuilder.DropColumn(
                name: "_Responsibility",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "User_UUID",
                table: "UserAnimalsIDs");

            migrationBuilder.DropColumn(
                name: "_Responsibility",
                table: "Clients");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserAnimalsIDs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimalsIDs_UserId",
                table: "UserAnimalsIDs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnimalsIDs_Users_UserId",
                table: "UserAnimalsIDs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "User_UUID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
