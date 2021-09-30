using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectApi.Migrations
{
    public partial class version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblSubjects",
                columns: table => new
                {
                    Subject_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSubjects", x => x.Subject_Id);
                });

            migrationBuilder.CreateTable(
                name: "TblQuestionSets",
                columns: table => new
                {
                    QuestionSet_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    SubjectRef_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblQuestionSets", x => x.QuestionSet_Id);
                    table.ForeignKey(
                        name: "FK_TblQuestionSets_TblSubjects_SubjectRef_Id",
                        column: x => x.SubjectRef_Id,
                        principalTable: "TblSubjects",
                        principalColumn: "Subject_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblQuestions",
                columns: table => new
                {
                    Question_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question_Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correct_Option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionSetRef_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblQuestions", x => x.Question_Id);
                    table.ForeignKey(
                        name: "FK_TblQuestions_TblQuestionSets_QuestionSetRef_Id",
                        column: x => x.QuestionSetRef_Id,
                        principalTable: "TblQuestionSets",
                        principalColumn: "QuestionSet_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblQuestions_QuestionSetRef_Id",
                table: "TblQuestions",
                column: "QuestionSetRef_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TblQuestionSets_SubjectRef_Id",
                table: "TblQuestionSets",
                column: "SubjectRef_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblQuestions");

            migrationBuilder.DropTable(
                name: "TblQuestionSets");

            migrationBuilder.DropTable(
                name: "TblSubjects");
        }
    }
}
