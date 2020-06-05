using Microsoft.EntityFrameworkCore.Migrations;

namespace Virtuality.API.Migrations
{
    public partial class updatedCourseAndAddedVideos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "address",
                table: "Teachers",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "level",
                table: "Courses",
                newName: "Level");

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SequenceNumber = table.Column<int>(nullable: false),
                    VideoName = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_CourseId",
                table: "Videos",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Teachers",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Courses",
                newName: "level");
        }
    }
}
