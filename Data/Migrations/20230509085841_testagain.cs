using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalAfterlife2._0.Data.Migrations
{
    /// <inheritdoc />
    public partial class testagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Perished_PerishedId1",
                table: "File");

            migrationBuilder.DropIndex(
                name: "IX_File_PerishedId1",
                table: "File");

            migrationBuilder.DropColumn(
                name: "PerishedId1",
                table: "File");

            migrationBuilder.AlterColumn<int>(
                name: "PerishedId",
                table: "File",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_File_PerishedId",
                table: "File",
                column: "PerishedId");

            migrationBuilder.AddForeignKey(
                name: "FK_File_Perished_PerishedId",
                table: "File",
                column: "PerishedId",
                principalTable: "Perished",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Perished_PerishedId",
                table: "File");

            migrationBuilder.DropIndex(
                name: "IX_File_PerishedId",
                table: "File");

            migrationBuilder.AlterColumn<string>(
                name: "PerishedId",
                table: "File",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PerishedId1",
                table: "File",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_PerishedId1",
                table: "File",
                column: "PerishedId1");

            migrationBuilder.AddForeignKey(
                name: "FK_File_Perished_PerishedId1",
                table: "File",
                column: "PerishedId1",
                principalTable: "Perished",
                principalColumn: "Id");
        }
    }
}
