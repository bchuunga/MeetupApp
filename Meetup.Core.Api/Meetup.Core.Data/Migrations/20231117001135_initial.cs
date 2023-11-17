using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Meetup.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(150)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(150)", nullable: false),
                    Nationality = table.Column<string>(type: "varchar(150)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meetups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Organizer = table.Column<string>(type: "varchar(150)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetups_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "varchar(150)", nullable: false),
                    Topic = table.Column<string>(type: "varchar(150)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    MeetupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_Meetups_MeetupId",
                        column: x => x.MeetupId,
                        principalTable: "Meetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "varchar(150)", nullable: false),
                    Street = table.Column<string>(type: "varchar(150)", nullable: false),
                    PostCode = table.Column<string>(type: "varchar(6)", nullable: false),
                    MeetupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Meetups_MeetupId",
                        column: x => x.MeetupId,
                        principalTable: "Meetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Moderator" },
                    { 3, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Nationality", "PasswordHash", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2003, 11, 16, 16, 11, 35, 883, DateTimeKind.Local).AddTicks(4543), "admin@email.com", "admin", "admin", "American", "pass1", 1 },
                    { 2, new DateTime(2013, 11, 16, 16, 11, 35, 883, DateTimeKind.Local).AddTicks(4591), "moderator@email.com", "moderator", "moderator", "American", "pass1", 2 },
                    { 3, new DateTime(1968, 11, 16, 16, 11, 35, 883, DateTimeKind.Local).AddTicks(4595), "user@email.com", "user", "user", "American", "pass1", 3 }
                });

            migrationBuilder.InsertData(
                table: "Meetups",
                columns: new[] { "Id", "CreatedById", "Date", "IsPrivate", "Name", "Organizer" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 11, 26, 16, 11, 35, 883, DateTimeKind.Local).AddTicks(4607), true, "Angular 17", "Google" },
                    { 2, 2, new DateTime(2023, 7, 29, 16, 11, 35, 883, DateTimeKind.Local).AddTicks(4612), false, ".NET 8", "Microsoft" },
                    { 3, 3, new DateTime(2024, 1, 5, 16, 11, 35, 883, DateTimeKind.Local).AddTicks(4614), true, "SQL", "Microsoft" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_MeetupId",
                table: "Lectures",
                column: "MeetupId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_MeetupId",
                table: "Locations",
                column: "MeetupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meetups_CreatedById",
                table: "Meetups",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Meetups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
