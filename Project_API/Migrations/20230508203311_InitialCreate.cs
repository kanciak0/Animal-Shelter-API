using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Animal_UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Animal_UUID);
                });

            migrationBuilder.CreateTable(
                name: "Shelters",
                columns: table => new
                {
                    AnimalShelter_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.AnimalShelter_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    State = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserAddress_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAddress_HouseNumber = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_UUID);
                });

            migrationBuilder.CreateTable(
                name: "Adoption",
                columns: table => new
                {
                    AdoptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelteredAnimal_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Client_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalShelter_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoption", x => x.AdoptionID);
                    table.ForeignKey(
                        name: "FK_Adoption_Shelters_AnimalShelter_id",
                        column: x => x.AnimalShelter_id,
                        principalTable: "Shelters",
                        principalColumn: "AnimalShelter_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Client_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    _Responsibility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    animal_shelter_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Client_ID);
                    table.ForeignKey(
                        name: "FK_Clients_Shelters_animal_shelter_Id",
                        column: x => x.animal_shelter_Id,
                        principalTable: "Shelters",
                        principalColumn: "AnimalShelter_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShelteredAnimal",
                columns: table => new
                {
                    ShelteredAnimal_UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShelteredAnimalSpecies = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    animal_shelter_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelteredAnimal", x => x.ShelteredAnimal_UUID);
                    table.ForeignKey(
                        name: "FK_ShelteredAnimal_Shelters_animal_shelter_Id",
                        column: x => x.animal_shelter_Id,
                        principalTable: "Shelters",
                        principalColumn: "AnimalShelter_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAnimals",
                columns: table => new
                {
                    Animal_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnimals", x => x.Animal_ID);
                    table.ForeignKey(
                        name: "FK_UserAnimals_Users_User_UUID",
                        column: x => x.User_UUID,
                        principalTable: "Users",
                        principalColumn: "User_UUID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adoption_AnimalShelter_id",
                table: "Adoption",
                column: "AnimalShelter_id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_animal_shelter_Id",
                table: "Clients",
                column: "animal_shelter_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShelteredAnimal_animal_shelter_Id",
                table: "ShelteredAnimal",
                column: "animal_shelter_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_User_UUID",
                table: "UserAnimals",
                column: "User_UUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adoption");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ShelteredAnimal");

            migrationBuilder.DropTable(
                name: "UserAnimals");

            migrationBuilder.DropTable(
                name: "Shelters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
