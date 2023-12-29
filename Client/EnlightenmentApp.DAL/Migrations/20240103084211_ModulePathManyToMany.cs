using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnlightenmentApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModulePathManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Paths_PathEntityId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_PathEntityId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "PathEntityId",
                table: "Modules");

            migrationBuilder.CreateTable(
                name: "ModuleEntityPathEntity",
                columns: table => new
                {
                    ModulesId = table.Column<int>(type: "int", nullable: false),
                    PathsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleEntityPathEntity", x => new { x.ModulesId, x.PathsId });
                    table.ForeignKey(
                        name: "FK_ModuleEntityPathEntity_Modules_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleEntityPathEntity_Paths_PathsId",
                        column: x => x.PathsId,
                        principalTable: "Paths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleEntityPathEntity_PathsId",
                table: "ModuleEntityPathEntity",
                column: "PathsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleEntityPathEntity");

            migrationBuilder.AddColumn<int>(
                name: "PathEntityId",
                table: "Modules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_PathEntityId",
                table: "Modules",
                column: "PathEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Paths_PathEntityId",
                table: "Modules",
                column: "PathEntityId",
                principalTable: "Paths",
                principalColumn: "Id");
        }
    }
}
