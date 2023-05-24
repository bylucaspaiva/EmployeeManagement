using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Migrations
{
    /// <inheritdoc />
    public partial class updateEmployeeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTitles_Employees_EmployeeRegisterNumber",
                table: "JobTitles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeRegisterNumber",
                table: "JobTitles",
                newName: "EmployeeGuid");

            migrationBuilder.RenameIndex(
                name: "IX_JobTitles_EmployeeRegisterNumber",
                table: "JobTitles",
                newName: "IX_JobTitles_EmployeeGuid");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTitles_Employees_EmployeeGuid",
                table: "JobTitles",
                column: "EmployeeGuid",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTitles_Employees_EmployeeGuid",
                table: "JobTitles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeGuid",
                table: "JobTitles",
                newName: "EmployeeRegisterNumber");

            migrationBuilder.RenameIndex(
                name: "IX_JobTitles_EmployeeGuid",
                table: "JobTitles",
                newName: "IX_JobTitles_EmployeeRegisterNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "RegisterNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTitles_Employees_EmployeeRegisterNumber",
                table: "JobTitles",
                column: "EmployeeRegisterNumber",
                principalTable: "Employees",
                principalColumn: "RegisterNumber");
        }
    }
}
