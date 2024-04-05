using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clarity_Crate.Data.Migrations
{
    public partial class TopicCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Curriculum",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Topic_TopicId",
                table: "Subject");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_Subject_TopicId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Subject");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Curriculum",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
