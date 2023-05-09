using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalAfterlife2._0.Data.Migrations
{
    /// <inheritdoc />
    public partial class ScaffoldedItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NextOfKin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextOfKin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perished",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialSecurity = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deathcert = table.Column<bool>(type: "bit", nullable: true),
                    Fullmakt = table.Column<bool>(type: "bit", nullable: true),
                    NextOfKinId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perished", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perished_NextOfKin_NextOfKinId",
                        column: x => x.NextOfKinId,
                        principalTable: "NextOfKin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UploadedFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfUpload = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PerishedId1 = table.Column<int>(type: "int", nullable: true),
                    PerishedId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Perished_PerishedId1",
                        column: x => x.PerishedId1,
                        principalTable: "Perished",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_File_PerishedId1",
                table: "File",
                column: "PerishedId1");

            migrationBuilder.CreateIndex(
                name: "IX_Perished_NextOfKinId",
                table: "Perished",
                column: "NextOfKinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Perished");

            migrationBuilder.DropTable(
                name: "NextOfKin");
        }
    }
}
