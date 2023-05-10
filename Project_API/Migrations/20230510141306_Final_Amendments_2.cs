using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_API.Migrations
{
    /// <inheritdoc />
    public partial class Final_Amendments_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnimals_Users_User_UUID",
                table: "UserAnimals");

            migrationBuilder.DropIndex(
                name: "IX_UserAnimals_User_UUID",
                table: "UserAnimals");

            migrationBuilder.DropColumn(
                name: "User_UUID",
                table: "UserAnimals");

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "UserAnimals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_user_id",
                table: "UserAnimals",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnimals_Users_user_id",
                table: "UserAnimals",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "User_UUID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnimals_Users_user_id",
                table: "UserAnimals");

            migrationBuilder.DropIndex(
                name: "IX_UserAnimals_user_id",
                table: "UserAnimals");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "UserAnimals");

            migrationBuilder.AddColumn<Guid>(
                name: "User_UUID",
                table: "UserAnimals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_User_UUID",
                table: "UserAnimals",
                column: "User_UUID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnimals_Users_User_UUID",
                table: "UserAnimals",
                column: "User_UUID",
                principalTable: "Users",
                principalColumn: "User_UUID");
        }
    }
}
