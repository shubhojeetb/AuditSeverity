using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditSeverityModule.Migrations
{
    public partial class ChangePrimaryKeyOfQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionNo",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "QuestionNo",
                table: "Questions",
                nullable: true
                );

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Questions",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionNo",
                table: "Questions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "QuestionNo");
        }
    }
}
