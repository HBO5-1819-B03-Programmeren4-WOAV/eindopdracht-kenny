using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B03.EE.BlanckeK.Api.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    QuizId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuizName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.QuizId);
                    table.ForeignKey(
                        name: "FK_Quiz_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionText = table.Column<string>(nullable: true),
                    QuizId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    AnswerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerText = table.Column<string>(nullable: true),
                    IsCorrectAnswer = table.Column<bool>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answer_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "DateTime", "FirstName", "LastName", "Password" },
                values: new object[] { 1, new DateTime(2018, 12, 28, 13, 49, 5, 923, DateTimeKind.Local).AddTicks(5052), "Kenny", "Blancke", "Test" });

            migrationBuilder.InsertData(
                table: "Quiz",
                columns: new[] { "QuizId", "QuizName", "UserId" },
                values: new object[] { 1, "Eerste quiz", 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "QuestionText", "QuizId" },
                values: new object[] { 1, "Eerste vraag?", 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "QuestionText", "QuizId" },
                values: new object[] { 2, "Tweede vraag?", 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "QuestionText", "QuizId" },
                values: new object[] { 3, "Derde vraag?", 1 });

            migrationBuilder.InsertData(
                table: "Answer",
                columns: new[] { "AnswerId", "AnswerText", "IsCorrectAnswer", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Correct antwoord op eerste vraag", true, 1 },
                    { 2, "Eerste foutieve antwoord op eerste vraag", false, 1 },
                    { 3, "tweede foutieve antwoord op eerste vraag", false, 1 },
                    { 4, "derde foutieve antwoord op eerste vraag", false, 1 },
                    { 5, "Eerste foutieve antwoord op tweede vraag", false, 2 },
                    { 6, "Tweede foutieve antwoord op tweede vraag", false, 2 },
                    { 7, "Juiste antwoord op tweede vraag", true, 2 },
                    { 8, "derde foutieve antwoord op tweede vraag", false, 2 },
                    { 9, "Correct antwoord op derde vraag", true, 3 },
                    { 10, "Eerste foutieve antwoord op derde vraag", false, 3 },
                    { 11, "tweede foutieve antwoord op derde vraag", false, 3 },
                    { 12, "derde foutieve antwoord op derde vraag", false, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_UserId",
                table: "Quiz",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
