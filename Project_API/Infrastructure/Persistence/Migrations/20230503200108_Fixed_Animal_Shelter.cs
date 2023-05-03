using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_API.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_Animal_Shelter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnimalsIDs");

            migrationBuilder.RenameColumn(
                name: "Client_IDs",
                table: "Adoption",
                newName: "Client_ID");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ShelteredAnimal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "animal_shelter_Id",
                table: "ShelteredAnimal",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "animal_shelter_Id",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnimalShelter_ID",
                table: "Adoption",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Shelters",
                columns: table => new
                {
                    AnimalShelter_ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.AnimalShelter_ID);
                });

            migrationBuilder.CreateTable(
                name: "UserAnimalsID",
                columns: table => new
                {
                    User_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnimalsID", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_UserAnimalsID_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShelteredAnimal_animal_shelter_Id",
                table: "ShelteredAnimal",
                column: "animal_shelter_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_animal_shelter_Id",
                table: "Clients",
                column: "animal_shelter_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Adoption_AnimalShelter_ID",
                table: "Adoption",
                column: "AnimalShelter_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adoption_Shelters_AnimalShelter_ID",
                table: "Adoption",
                column: "AnimalShelter_ID",
                principalTable: "Shelters",
                principalColumn: "AnimalShelter_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Shelters_animal_shelter_Id",
                table: "Clients",
                column: "animal_shelter_Id",
                principalTable: "Shelters",
                principalColumn: "AnimalShelter_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShelteredAnimal_Shelters_animal_shelter_Id",
                table: "ShelteredAnimal",
                column: "animal_shelter_Id",
                principalTable: "Shelters",
                principalColumn: "AnimalShelter_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adoption_Shelters_AnimalShelter_ID",
                table: "Adoption");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Shelters_animal_shelter_Id",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_ShelteredAnimal_Shelters_animal_shelter_Id",
                table: "ShelteredAnimal");

            migrationBuilder.DropTable(
                name: "Shelters");

            migrationBuilder.DropTable(
                name: "UserAnimalsID");

            migrationBuilder.DropIndex(
                name: "IX_ShelteredAnimal_animal_shelter_Id",
                table: "ShelteredAnimal");

            migrationBuilder.DropIndex(
                name: "IX_Clients_animal_shelter_Id",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Adoption_AnimalShelter_ID",
                table: "Adoption");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ShelteredAnimal");

            migrationBuilder.DropColumn(
                name: "animal_shelter_Id",
                table: "ShelteredAnimal");

            migrationBuilder.DropColumn(
                name: "animal_shelter_Id",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "AnimalShelter_ID",
                table: "Adoption");

            migrationBuilder.RenameColumn(
                name: "Client_ID",
                table: "Adoption",
                newName: "Client_IDs");

            migrationBuilder.CreateTable(
                name: "UserAnimalsIDs",
                columns: table => new
                {
                    Value = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnimalsIDs", x => x.Value);
                    table.ForeignKey(
                        name: "FK_UserAnimalsIDs_Users_User_UUID",
                        column: x => x.User_UUID,
                        principalTable: "Users",
                        principalColumn: "User_UUID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimalsIDs_User_UUID",
                table: "UserAnimalsIDs",
                column: "User_UUID");
        }
    }
}
