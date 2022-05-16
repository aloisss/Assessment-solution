using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recruitment.Data.Migrations
{
    public partial class initialChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "application",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_of_application = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application", x => x.ApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "test",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Max_score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test", x => x.TestId);
                });

            migrationBuilder.CreateTable(
                name: "application_test",
                columns: table => new
                {
                    ApplicationTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    Starting_day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ending_day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_test", x => x.ApplicationTestId);
                    table.ForeignKey(
                        name: "FK_application_test_application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_application_test_test_TestId",
                        column: x => x.TestId,
                        principalTable: "test",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total_grades = table.Column<int>(type: "int", nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer_details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationTestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswersId);
                    table.ForeignKey(
                        name: "FK_Answers_application_test_ApplicationTestId",
                        column: x => x.ApplicationTestId,
                        principalTable: "application_test",
                        principalColumn: "ApplicationTestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "interview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationID = table.Column<int>(type: "int", nullable: false),
                    application_testApplicationTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_interview_application_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_interview_application_test_application_testApplicationTestId",
                        column: x => x.application_testApplicationTestId,
                        principalTable: "application_test",
                        principalColumn: "ApplicationTestId");
                });

            migrationBuilder.CreateTable(
                name: "interviewNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interviewNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_interviewNotes_interview_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "interview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ApplicationTestId",
                table: "Answers",
                column: "ApplicationTestId");

            migrationBuilder.CreateIndex(
                name: "IX_application_test_ApplicationId",
                table: "application_test",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_application_test_TestId",
                table: "application_test",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_interview_application_testApplicationTestId",
                table: "interview",
                column: "application_testApplicationTestId");

            migrationBuilder.CreateIndex(
                name: "IX_interview_ApplicationID",
                table: "interview",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_interviewNotes_InterviewId",
                table: "interviewNotes",
                column: "InterviewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "interviewNotes");

            migrationBuilder.DropTable(
                name: "interview");

            migrationBuilder.DropTable(
                name: "application_test");

            migrationBuilder.DropTable(
                name: "application");

            migrationBuilder.DropTable(
                name: "test");
        }
    }
}
