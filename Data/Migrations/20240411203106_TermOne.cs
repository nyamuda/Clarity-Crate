using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clarity_Crate.Data.Migrations
{
    public partial class TermOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Definition_TermId",
                table: "Definition");

            migrationBuilder.AddColumn<int>(
                name: "DefinitionId",
                table: "Term",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TermLevel",
                columns: table => new
                {
                    LevelsId = table.Column<int>(type: "int", nullable: false),
                    TermsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermLevel", x => new { x.LevelsId, x.TermsId });
                    table.ForeignKey(
                        name: "FK_TermLevel_Level_LevelsId",
                        column: x => x.LevelsId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TermLevel_Term_TermsId",
                        column: x => x.TermsId,
                        principalTable: "Term",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Definition_TermId",
                table: "Definition",
                column: "TermId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TermLevel_TermsId",
                table: "TermLevel",
                column: "TermsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TermLevel");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropIndex(
                name: "IX_Definition_TermId",
                table: "Definition");

            migrationBuilder.DropColumn(
                name: "DefinitionId",
                table: "Term");

            migrationBuilder.CreateIndex(
                name: "IX_Definition_TermId",
                table: "Definition",
                column: "TermId");
        }
    }
}
