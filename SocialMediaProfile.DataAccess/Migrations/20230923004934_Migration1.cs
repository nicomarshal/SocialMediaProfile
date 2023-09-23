using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaProfile.DataAccess.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Career = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_People_PersonId",
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                table: "People",
                columns: new[] { "Id", "AboutMe", "IsDeleted", "Name", "Profession", "ProfileImg", "Surname", "UserId" },
                values: new object[] { 1, "Simpàtico y curioso", false, "Gian", "Matemàtico", "imgGian", "Ledesma", 1 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "AboutMe", "IsDeleted", "Name", "Profession", "ProfileImg", "Surname", "UserId" },
                values: new object[] { 2, "Mùsico y curioso", false, "Nicolàs", "Desarrollador", "imgNico", "Ledesma", 2 });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "Career", "Description", "FinishDate", "IsDeleted", "Logo", "Name", "PersonId", "StartDate" },
                values: new object[,]
                {
                    { 1, "Licenciatura en Matemática", "Carrera universitaria de 5 años", new DateTime(2023, 9, 22, 21, 49, 33, 967, DateTimeKind.Local).AddTicks(6814), false, "imgEducGian", "FAMAF - UNC", 1, new DateTime(2023, 9, 22, 21, 49, 33, 967, DateTimeKind.Local).AddTicks(6813) },
                    { 2, "Ingenierìa en Computaciòn", "Carrera universitaria de 5 años", new DateTime(2023, 9, 22, 21, 49, 33, 967, DateTimeKind.Local).AddTicks(6816), false, "imgEducNico", "FCEFyN - UNC", 2, new DateTime(2023, 9, 22, 21, 49, 33, 967, DateTimeKind.Local).AddTicks(6815) }
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "Description", "FinishDate", "IsDeleted", "Job", "Logo", "Name", "PersonId", "StartDate" },
                values: new object[,]
                {
                    { 1, "Centro de investigaciòn nacional", new DateTime(2023, 9, 22, 21, 49, 33, 967, DateTimeKind.Local).AddTicks(6797), false, "Cientìfico", "imgExpGian", "CONICET", 1, new DateTime(2023, 9, 22, 21, 49, 33, 967, DateTimeKind.Local).AddTicks(6784) },
                    { 2, "Automatizaciones industriales", new DateTime(2023, 9, 22, 21, 49, 33, 967, DateTimeKind.Local).AddTicks(6799), false, "Desarrollador .NET", "imgExpNico", "eFALCOM", 2, new DateTime(2023, 9, 22, 21, 49, 33, 967, DateTimeKind.Local).AddTicks(6798) }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "FinishDate", "Images", "IsDeleted", "Name", "PersonId", "StartDate", "URL" },
                values: new object[,]
                {
                    { 1, "Robot construido con bloques", new DateTime(2023, 9, 22, 21, 49, 33, 967, DateTimeKind.Local).AddTicks(6837), "ImagesGian", false, "Robot 3D", 1, new DateTime(2023, 9, 22, 21, 49, 33, 967, DateTimeKind.Local).AddTicks(6836), "https://" },
                    { 2, "App de mensajerìa", new DateTime(2023, 9, 22, 21, 49, 33, 967, DateTimeKind.Local).AddTicks(6839), "ImagesNico", false, "ChatApp", 2, new DateTime(2023, 9, 22, 21, 49, 33, 967, DateTimeKind.Local).AddTicks(6838), "https://" }
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
                name: "IX_Experiences_PersonId",
                table: "Experiences",
                column: "PersonId");

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
