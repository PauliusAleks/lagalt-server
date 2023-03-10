﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lagalt_web_api.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageUrls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUrls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GitURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserStatus = table.Column<bool>(type: "bit", nullable: false),
                    Portofolio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageUrlProject",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUrlProject", x => new { x.ProjectId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_ImageUrlProject_ImageUrls_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ImageUrls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageUrlProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSkill",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkill", x => new { x.SkillId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectSkill_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminProject",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminProject", x => new { x.ProjectId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_AdminProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminProject_Users_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(type: "int", nullable: false),
                    MotivationLetter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContributorProject",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributorProject", x => new { x.ProjectId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_ContributorProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContributorProject_Users_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkill",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkill", x => new { x.SkillId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkill_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ImageUrls",
                columns: new[] { "Id", "Url" },
                values: new object[,]
                {
                    { 1, "https://picsum.photos/200/350,https://picsum.photos/200/250" },
                    { 2, "https://m.media-amazon.com/images/M/MV5BZmQ3MWEyNTYtOTY1OC00MTljLWI3OGUtMmU1ZDc2OTYxNDQ4L2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMTczNjQwOTY@._V1_.jpg" },
                    { 3, "https://www.aboutmusictheory.com/wp-content/uploads/2012/04/composing-music-verse-pop-song.jpg" },
                    { 4, "https://picsum.photos/200/300" },
                    { 5, "https://www.youtube.com/watch?v=LkWQvzrv6gI" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Category", "Description", "GitURL", "Name", "Progress" },
                values: new object[,]
                {
                    { 1, 3, "Joachim Rønning", "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/C6AB0EDCE8F41882EBBB782B76DD4F05D7E360D7C3F23B4F6D02C24699B26105/scale?width=1200&aspectRatio=1.78&format=jpeg", "Tinder v2", 0 },
                    { 2, 3, "Looking for a c# back-end developer", "https://gitlab.com/Frechr/assignment-three/-/tree/master/", "EF_CodeFirst", 0 },
                    { 3, 3, "Web app to catch pokemons!", "https://gitlab.com/JarandNL/angular_pokemontrainer", "Exciting_Angular_Project", 1 },
                    { 4, 1, "Hot youth!!!!", "https://www.imdb.com/title/tt0475293/", "High School Musical", 3 },
                    { 5, 0, "Pls help make the best song ever", null, "Best song ever!!!", 1 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Java" },
                    { 2, "C#" },
                    { 3, "Photoshop" },
                    { 4, "Sony Vegas" },
                    { 5, "Fruity Loops Studio" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "FirstName", "LastName", "Portofolio", "UserStatus", "Username" },
                values: new object[,]
                {
                    { 1, "User", "admin123@admin.no", "Admin", "Adminson", null, false, "adminBoy" },
                    { 2, "User", "PerPolle@sharkboy.no,", "Per", "Polle", null, true, "sharkboy05" },
                    { 3, "User", "testing123@Proper.no", "Proper", "Userito", null, false, "ProperUser" },
                    { 4, "User", "BobBobby@mail.no", "Bob", "Forr", null, true, "StrangerHere" }
                });

            migrationBuilder.InsertData(
                table: "ProjectSkill",
                columns: new[] { "ProjectId", "SkillId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 5, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "UserSkill",
                columns: new[] { "SkillId", "UserId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 4 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminProject_ProjectsId",
                table: "AdminProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ProjectId",
                table: "Applications",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContributorProject_ProjectsId",
                table: "ContributorProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageUrlProject_ProjectsId",
                table: "ImageUrlProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkill_ProjectId",
                table: "ProjectSkill",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_UserId",
                table: "UserSkill",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminProject");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "ContributorProject");

            migrationBuilder.DropTable(
                name: "ImageUrlProject");

            migrationBuilder.DropTable(
                name: "ProjectSkill");

            migrationBuilder.DropTable(
                name: "UserSkill");

            migrationBuilder.DropTable(
                name: "ImageUrls");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
