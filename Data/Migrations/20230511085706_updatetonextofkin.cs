using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalAfterlife2._0.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetonextofkin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "NextOfKin");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "NextOfKin",
                newName: "PhoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "NextOfKin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BirthDate",
                table: "NextOfKin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "NextOfKin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "NextOfKin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "NextOfKin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SocialSecurity",
                table: "NextOfKin",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "NextOfKin");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "NextOfKin");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "NextOfKin");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "NextOfKin");

            migrationBuilder.DropColumn(
                name: "SocialSecurity",
                table: "NextOfKin");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "NextOfKin",
                newName: "Surname");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "NextOfKin",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "NextOfKin",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
