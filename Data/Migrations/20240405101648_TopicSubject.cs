using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clarity_Crate.Data.Migrations
{
    public partial class TopicSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Topic_TopicId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_TopicId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Subject");

            migrationBuilder.CreateTable(
                name: "TopicSubject",
                columns: table => new
                {
                    SubjectsId = table.Column<int>(type: "int", nullable: false),
                    TopicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicSubject", x => new { x.SubjectsId, x.TopicsId });
                    table.ForeignKey(
                        name: "FK_TopicSubject_Subject_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicSubject_Topic_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicSubject_TopicsId",
                table: "TopicSubject",
                column: "TopicsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicSubject");

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subject_TopicId",
                table: "Subject",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Topic_TopicId",
                table: "Subject",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id");
        }
    }
}
