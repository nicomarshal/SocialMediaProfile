using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaProfile.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Career = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[] { 1, "Usuario Administrador", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[] { 2, "Usuario Regular", false, "Regular" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Password", "RoleId", "Username" },
                values: new object[] { 1, "gianledesma@gmail.com", false, "gian123", 1, "Gian123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Password", "RoleId", "Username" },
                values: new object[] { 2, "nicoledesma@gmail.com", false, "nico123", 2, "Nico123" });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "Description", "FinishDate", "IsDeleted", "Job", "Logo", "Name", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Centro de investigaciòn nacional", new DateTime(2023, 10, 16, 19, 7, 27, 417, DateTimeKind.Local).AddTicks(4020), false, "Cientìfico", "imgExpGian", "CONICET", new DateTime(2023, 10, 16, 19, 7, 27, 417, DateTimeKind.Local).AddTicks(4005), 1 },
                    { 2, "Automatizaciones industriales", new DateTime(2023, 10, 16, 19, 7, 27, 417, DateTimeKind.Local).AddTicks(4022), false, "Desarrollador .NET", "imgExpNico", "eFALCOM", new DateTime(2023, 10, 16, 19, 7, 27, 417, DateTimeKind.Local).AddTicks(4021), 2 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "AboutMe", "IsDeleted", "Name", "Profession", "ProfileImg", "Surname", "UserId" },
                values: new object[,]
                {
                    { 1, "Simpàtico y curioso", false, "Gian", "Matemàtico", "imgGian", "Ledesma", 1 },
                    { 2, "Mùsico y curioso", false, "Nicolàs", "Desarrollador", "imgNico", "Ledesma", 2 }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "Career", "Description", "FinishDate", "IsDeleted", "Logo", "Name", "PersonId", "StartDate" },
                values: new object[,]
                {
                    { 1, "Licenciatura en Matemática", "Carrera universitaria de 5 años", new DateTime(2023, 10, 16, 19, 7, 27, 417, DateTimeKind.Local).AddTicks(4032), false, "imgEducGian", "FAMAF - UNC", 1, new DateTime(2023, 10, 16, 19, 7, 27, 417, DateTimeKind.Local).AddTicks(4031) },
                    { 2, "Ingenierìa en Computaciòn", "Carrera universitaria de 5 años", new DateTime(2023, 10, 16, 19, 7, 27, 417, DateTimeKind.Local).AddTicks(4034), false, "imgEducNico", "FCEFyN - UNC", 2, new DateTime(2023, 10, 16, 19, 7, 27, 417, DateTimeKind.Local).AddTicks(4034) }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "FinishDate", "Images", "IsDeleted", "Name", "PersonId", "StartDate", "URL" },
                values: new object[,]
                {
                    { 1, "Robot construido con bloques", new DateTime(2023, 10, 16, 19, 7, 27, 417, DateTimeKind.Local).AddTicks(4055), "ImagesGian", false, "Robot 3D", 1, new DateTime(2023, 10, 16, 19, 7, 27, 417, DateTimeKind.Local).AddTicks(4054), "https://" },
                    { 2, "App de mensajerìa", new DateTime(2023, 10, 16, 19, 7, 27, 417, DateTimeKind.Local).AddTicks(4057), "ImagesNico", false, "ChatApp", 2, new DateTime(2023, 10, 16, 19, 7, 27, 417, DateTimeKind.Local).AddTicks(4056), "https://" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "IsDeleted", "Name", "Percentage", "PersonId" },
                values: new object[,]
                {
                    { 1, false, "imgSKGian", 95, 1 },
                    { 2, false, "imgSkNico", 95, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_PersonId",
                table: "Educations",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_UserId",
                table: "Experiences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_People_UserId",
                table: "People",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PersonId",
                table: "Projects",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_PersonId",
                table: "Skills",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
