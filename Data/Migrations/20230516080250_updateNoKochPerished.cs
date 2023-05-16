using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalAfterlife2._0.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateNoKochPerished : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Perished",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Perished",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Perished",
                newName: "Gender");

            migrationBuilder.AddColumn<int>(
                name: "BirthDate",
                table: "Perished",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Perished");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Perished",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Perished",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Perished",
                newName: "MiddleName");
        }
    }
}
