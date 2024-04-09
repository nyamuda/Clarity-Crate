using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clarity_Crate.Data.Migrations
{
    public partial class DefinitionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Term_Topic_TopicId",
                table: "Term");

            migrationBuilder.DropIndex(
                name: "IX_Term_TopicId",
                table: "Term");

            migrationBuilder.DropColumn(
                name: "Definition",
                table: "Term");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Term");

            migrationBuilder.CreateTable(
                name: "Definition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Definition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Definition_Curriculum_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Definition_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Definition_Term_TermId",
                        column: x => x.TermId,
                        principalTable: "Term",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Definition_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Definition_CurriculumId",
                table: "Definition",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Definition_SubjectId",
                table: "Definition",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Definition_TermId",
                table: "Definition",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_Definition_TopicId",
                table: "Definition",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Definition");

            migrationBuilder.AddColumn<string>(
                name: "Definition",
                table: "Term",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Term",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Term_TopicId",
                table: "Term",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Term_Topic_TopicId",
                table: "Term",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
