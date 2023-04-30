﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_API.Infrastructure.Persistence;

#nullable disable

namespace Project_API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230415125503_User_Responsibility")]
    partial class User_Responsibility
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ForbiddenList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Client_ids")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Client_IDs");

                    b.Property<string>("ShelteredAnimal_ids")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ShelteredAnimal_Id");

                    b.HasKey("Id");

                    b.ToTable("ForbiddenList", (string)null);
                });

            modelBuilder.Entity("Project_API.Entities.AnimalAggregate.Animal", b =>
                {
                    b.Property<Guid>("Animal_UUID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Animal_UUID");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("Animal_UUID");

                    b.ToTable("Animals", (string)null);
                });

            modelBuilder.Entity("Project_API.Entities.Animal_ShelterAggregate.Adoption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AdoptionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Client_ids")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Client_IDs");

                    b.Property<string>("ShelteredAnimal_ids")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ShelteredAnimal_IDs");

                    b.HasKey("Id");

                    b.ToTable("Adoption", (string)null);
                });

            modelBuilder.Entity("Project_API.Entities.Animal_ShelterAggregate.Client", b =>
                {
                    b.Property<Guid>("Client_UUID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Client_ID");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_Responsibility")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Client_UUID");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("Project_API.Entities.Animal_ShelterAggregate.ShelteredAnimal", b =>
                {
                    b.Property<Guid>("ShelteredAnimal_UUID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ShelteredAnimal_UUID");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Name");

                    b.HasKey("ShelteredAnimal_UUID");

                    b.ToTable("ShelteredAnimal", (string)null);
                });

            modelBuilder.Entity("Project_API.Entities.UserAggregate.User", b =>
                {
                    b.Property<Guid>("User_UUID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("User_UUID");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_Responsibility")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_UUID");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Project_API.Entities.UserAggregate.UserAnimalsID", b =>
                {
                    b.Property<Guid>("Value")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Value");

                    b.Property<Guid?>("User_UUID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Value");

                    b.HasIndex("User_UUID");

                    b.ToTable("UserAnimalsIDs", (string)null);
                });

            modelBuilder.Entity("Project_API.Entities.AnimalAggregate.Animal", b =>
                {
                    b.OwnsOne("Project_API.Entities.AnimalAggregate.Species", "Species", b1 =>
                        {
                            b1.Property<Guid>("Animal_UUID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("_Species")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("Species");

                            b1.HasKey("Animal_UUID");

                            b1.ToTable("Animals");

                            b1.WithOwner()
                                .HasForeignKey("Animal_UUID");
                        });

                    b.Navigation("Species")
                        .IsRequired();
                });

            modelBuilder.Entity("Project_API.Entities.Animal_ShelterAggregate.Client", b =>
                {
                    b.OwnsOne("Project_API.Entities.Animal_ShelterAggregate.ClientAddress", "Address", b1 =>
                        {
                            b1.Property<Guid>("Client_UUID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("HouseNumber")
                                .HasColumnType("int")
                                .HasColumnName("HouseNumber");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("Street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ZipCode");

                            b1.HasKey("Client_UUID");

                            b1.ToTable("Clients");

                            b1.WithOwner()
                                .HasForeignKey("Client_UUID");
                        });

                    b.OwnsOne("Project_API.Entities.Animal_ShelterAggregate.ClientCredentials", "Credentials", b1 =>
                        {
                            b1.Property<Guid>("Client_UUID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("LastName");

                            b1.HasKey("Client_UUID");

                            b1.ToTable("Clients");

                            b1.WithOwner()
                                .HasForeignKey("Client_UUID");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Credentials")
                        .IsRequired();
                });

            modelBuilder.Entity("Project_API.Entities.Animal_ShelterAggregate.ShelteredAnimal", b =>
                {
                    b.OwnsOne("Project_API.Entities.Animal_ShelterAggregate.ShelteredAnimalSpecies", "Species", b1 =>
                        {
                            b1.Property<Guid>("ShelteredAnimal_UUID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("_ShelteredAnimalSpecies")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("ShelteredAnimalSpecies");

                            b1.HasKey("ShelteredAnimal_UUID");

                            b1.ToTable("ShelteredAnimal");

                            b1.WithOwner()
                                .HasForeignKey("ShelteredAnimal_UUID");
                        });

                    b.Navigation("Species")
                        .IsRequired();
                });

            modelBuilder.Entity("Project_API.Entities.UserAggregate.User", b =>
                {
                    b.OwnsOne("Project_API.Entities.UserAggregate.UserAddress", "UserAddress", b1 =>
                        {
                            b1.Property<Guid>("User_UUID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("Country");

                            b1.Property<int>("HouseNumber")
                                .HasColumnType("int");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("User_UUID");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("User_UUID");
                        });

                    b.OwnsOne("Project_API.Entities.UserAggregate.UserCredentials", "UserCredentials", b1 =>
                        {
                            b1.Property<Guid>("User_UUID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("Firstname");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("Lastname");

                            b1.HasKey("User_UUID");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("User_UUID");
                        });

                    b.Navigation("UserAddress")
                        .IsRequired();

                    b.Navigation("UserCredentials")
                        .IsRequired();
                });

            modelBuilder.Entity("Project_API.Entities.UserAggregate.UserAnimalsID", b =>
                {
                    b.HasOne("Project_API.Entities.UserAggregate.User", null)
                        .WithMany("AnimalIds")
                        .HasForeignKey("User_UUID");
                });

            modelBuilder.Entity("Project_API.Entities.UserAggregate.User", b =>
                {
                    b.Navigation("AnimalIds");
                });
#pragma warning restore 612, 618
        }
    }
}
