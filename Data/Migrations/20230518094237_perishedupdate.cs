using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalAfterlife2._0.Data.Migrations
{
    /// <inheritdoc />
    public partial class perishedupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreditCardNumber",
                table: "Perished",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Services",
                table: "Perished",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditCardNumber",
                table: "Perished");

            migrationBuilder.DropColumn(
                name: "Services",
                table: "Perished");
        }
    }
}
