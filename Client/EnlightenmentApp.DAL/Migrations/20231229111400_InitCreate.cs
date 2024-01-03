using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnlightenmentApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBasic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    PathEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Paths_PathEntityId",
                        column: x => x.PathEntityId,
                        principalTable: "Paths",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PathEntityTagEntity",
                columns: table => new
                {
                    PathsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PathEntityTagEntity", x => new { x.PathsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PathEntityTagEntity_Paths_PathsId",
                        column: x => x.PathsId,
                        principalTable: "Paths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PathEntityTagEntity_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleEntityTagEntity",
                columns: table => new
                {
                    ModulesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleEntityTagEntity", x => new { x.ModulesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ModuleEntityTagEntity_Modules_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleEntityTagEntity_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleReviews_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CheatSheet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_SectionId",
                table: "Chapters",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleEntityTagEntity_TagsId",
                table: "ModuleEntityTagEntity",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleReviews_ModuleId",
                table: "ModuleReviews",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_PathEntityId",
                table: "Modules",
                column: "PathEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PathEntityTagEntity_TagsId",
                table: "PathEntityTagEntity",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ModuleId",
                table: "Sections",
                column: "ModuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "ModuleEntityTagEntity");

            migrationBuilder.DropTable(
                name: "ModuleReviews");

            migrationBuilder.DropTable(
                name: "PathEntityTagEntity");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Paths");
        }
    }
}
