using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Migrations
{
    /// <inheritdoc />
    public partial class updateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobHistory");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TerminationDate",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeRegisterNumber",
                table: "JobTitles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "JobTitles",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TerminationDate",
                table: "JobTitles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobTitles_EmployeeRegisterNumber",
                table: "JobTitles",
                column: "EmployeeRegisterNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTitles_Employees_EmployeeRegisterNumber",
                table: "JobTitles",
                column: "EmployeeRegisterNumber",
                principalTable: "Employees",
                principalColumn: "RegisterNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTitles_Employees_EmployeeRegisterNumber",
                table: "JobTitles");

            migrationBuilder.DropIndex(
                name: "IX_JobTitles_EmployeeRegisterNumber",
                table: "JobTitles");

            migrationBuilder.DropColumn(
                name: "EmployeeRegisterNumber",
                table: "JobTitles");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "JobTitles");

            migrationBuilder.DropColumn(
                name: "TerminationDate",
                table: "JobTitles");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TerminationDate",
                table: "Employees",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeRegisterNumber = table.Column<string>(type: "TEXT", nullable: false),
                    JobTitleId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobHistory_Employees_EmployeeRegisterNumber",
                        column: x => x.EmployeeRegisterNumber,
                        principalTable: "Employees",
                        principalColumn: "RegisterNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobHistory_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobHistory_EmployeeRegisterNumber",
                table: "JobHistory",
                column: "EmployeeRegisterNumber");

            migrationBuilder.CreateIndex(
                name: "IX_JobHistory_JobTitleId",
                table: "JobHistory",
                column: "JobTitleId");
        }
    }
}
