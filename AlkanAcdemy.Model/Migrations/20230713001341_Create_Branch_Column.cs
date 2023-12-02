using Microsoft.EntityFrameworkCore.Migrations;

namespace AlkanAcademy.Model.Migrations
{
    public partial class Create_Branch_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstructorName",
                table: "Branches",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstructorSurname",
                table: "Branches",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PupilName",
                table: "Branches",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PupilSurname",
                table: "Branches",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstructorName",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "InstructorSurname",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "PupilName",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "PupilSurname",
                table: "Branches");
        }
    }
}
