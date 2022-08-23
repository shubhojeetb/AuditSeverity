using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditSeverityModule.Migrations
{
    public partial class AuditSeverityDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditBenchmarks",
                columns: table => new
                {
                    AuditBenchmarkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    auditType = table.Column<string>(nullable: true),
                    benchmarkNoAnswers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditBenchmarks", x => x.AuditBenchmarkId);
                });

            migrationBuilder.CreateTable(
                name: "AuditDetails",
                columns: table => new
                {
                    AuditDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditDetails", x => x.AuditDetailId);
                });

            migrationBuilder.CreateTable(
                name: "AuditResponses",
                columns: table => new
                {
                    AuditId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectExecutionStatus = table.Column<string>(nullable: true),
                    RemedialActionDuration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditResponses", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "AuditRequests",
                columns: table => new
                {
                    AuditRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true),
                    ProjectManagerName = table.Column<string>(nullable: true),
                    ApplicationOwnerName = table.Column<string>(nullable: true),
                    AuditdetailsAuditDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditRequests", x => x.AuditRequestId);
                    table.ForeignKey(
                        name: "FK_AuditRequests_AuditDetails_AuditdetailsAuditDetailId",
                        column: x => x.AuditdetailsAuditDetailId,
                        principalTable: "AuditDetails",
                        principalColumn: "AuditDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<bool>(nullable: false),
                    AuditDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionNo);
                    table.ForeignKey(
                        name: "FK_Questions_AuditDetails_AuditDetailId",
                        column: x => x.AuditDetailId,
                        principalTable: "AuditDetails",
                        principalColumn: "AuditDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditRequests_AuditdetailsAuditDetailId",
                table: "AuditRequests",
                column: "AuditdetailsAuditDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AuditDetailId",
                table: "Questions",
                column: "AuditDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditBenchmarks");

            migrationBuilder.DropTable(
                name: "AuditRequests");

            migrationBuilder.DropTable(
                name: "AuditResponses");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "AuditDetails");
        }
    }
}
