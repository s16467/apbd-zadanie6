using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cwiczenia_6.Migrations
{
    public partial class seededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_IdPrescription",
                        column: x => x.IdPrescription,
                        principalTable: "Doctors",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_IdPrescription",
                        column: x => x.IdPrescription,
                        principalTable: "Patients",
                        principalColumn: "IdPatient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    IdPrescription = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription_Medicaments", x => new { x.IdMedicament, x.IdPrescription });
                    table.ForeignKey(
                        name: "FK_Prescription_Medicaments_Medicaments_IdPrescription",
                        column: x => x.IdPrescription,
                        principalTable: "Medicaments",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Medicaments_Prescriptions_IdMedicament",
                        column: x => x.IdMedicament,
                        principalTable: "Prescriptions",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "j.brown@email.com", "John", "Brown" },
                    { 2, "a.white@email.com", "Andrew", "White" },
                    { 3, "w.anderson@email.com", "Walter", "Anderson" },
                    { 4, "m.handerson@email.com", "Mike", "Handerson" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Med1 Desc", "Med1", "pill" },
                    { 2, "Med2 Desc", "Med2", "cream" },
                    { 3, "Med3 Desc", "Med3", "vaccine" },
                    { 4, "Med4 Desc", "Med4", "antibiotics" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1993, 10, 15, 0, 0, 0, 0, DateTimeKind.Local), "Jordan", "Finney" },
                    { 2, new DateTime(1995, 12, 4, 0, 0, 0, 0, DateTimeKind.Local), "Gordon", "Ramsey" },
                    { 3, new DateTime(2005, 6, 23, 0, 0, 0, 0, DateTimeKind.Local), "Morgan", "Freewoman" },
                    { 4, new DateTime(2018, 1, 26, 0, 0, 0, 0, DateTimeKind.Local), "Chris", "Brown" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 11, 23, 32, 21, 133, DateTimeKind.Local).AddTicks(788), new DateTime(2021, 8, 11, 23, 32, 21, 133, DateTimeKind.Local).AddTicks(1992), 1, 2 },
                    { 2, new DateTime(2021, 6, 11, 23, 32, 21, 133, DateTimeKind.Local).AddTicks(4528), new DateTime(2021, 10, 11, 23, 32, 21, 133, DateTimeKind.Local).AddTicks(4558), 2, 2 },
                    { 3, new DateTime(2021, 6, 11, 23, 32, 21, 133, DateTimeKind.Local).AddTicks(4566), new DateTime(2021, 7, 11, 23, 32, 21, 133, DateTimeKind.Local).AddTicks(4571), 3, 1 },
                    { 4, new DateTime(2021, 6, 11, 23, 32, 21, 133, DateTimeKind.Local).AddTicks(4576), new DateTime(2022, 2, 11, 23, 32, 21, 133, DateTimeKind.Local).AddTicks(4580), 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 2, "details of prescription_medicament nr 1", null },
                    { 2, 1, "details of prescription_medicament nr 2", 200 },
                    { 3, 4, "details of prescription_medicament nr 4", 30 },
                    { 4, 3, "details of prescription_medicament nr 3", 300 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicaments_IdPrescription",
                table: "Prescription_Medicaments",
                column: "IdPrescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medicaments");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
