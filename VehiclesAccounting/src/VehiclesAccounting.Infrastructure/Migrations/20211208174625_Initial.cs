using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiclesAccounting.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFinish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Characteristics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicenseEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Categories = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExtraInformation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrafficPoliceOfficers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Post = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrafficPoliceOfficers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BodyNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EngineNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TechPassportNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DateCreating = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateInspection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    TrafficPoliceOfficerId = table.Column<int>(type: "int", nullable: true),
                    CarBrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarBrands_CarBrandId",
                        column: x => x.CarBrandId,
                        principalTable: "CarBrands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cars_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cars_TrafficPoliceOfficers_TrafficPoliceOfficerId",
                        column: x => x.TrafficPoliceOfficerId,
                        principalTable: "TrafficPoliceOfficers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StolenCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Circumstances = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarkAboutFinding = table.Column<bool>(type: "bit", nullable: false),
                    TheftDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InspectorId = table.Column<int>(type: "int", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StolenCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StolenCars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StolenCars_TrafficPoliceOfficers_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "TrafficPoliceOfficers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarBrandId",
                table: "Cars",
                column: "CarBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_OwnerId",
                table: "Cars",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TrafficPoliceOfficerId",
                table: "Cars",
                column: "TrafficPoliceOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_StolenCars_CarId",
                table: "StolenCars",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_StolenCars_InspectorId",
                table: "StolenCars",
                column: "InspectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StolenCars");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarBrands");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "TrafficPoliceOfficers");
        }
    }
}
