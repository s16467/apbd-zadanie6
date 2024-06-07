using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cwiczenia_6.Migrations
{
    public partial class alteredData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 1, 3, "details of prescription_medicament nr 3", 300 });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 40, 31, 648, DateTimeKind.Local).AddTicks(1493), new DateTime(2021, 8, 11, 23, 40, 31, 648, DateTimeKind.Local).AddTicks(2189) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 40, 31, 648, DateTimeKind.Local).AddTicks(3811), new DateTime(2021, 10, 11, 23, 40, 31, 648, DateTimeKind.Local).AddTicks(3823) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 40, 31, 648, DateTimeKind.Local).AddTicks(3829), new DateTime(2021, 7, 11, 23, 40, 31, 648, DateTimeKind.Local).AddTicks(3833) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 4,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 40, 31, 648, DateTimeKind.Local).AddTicks(3837), new DateTime(2022, 2, 11, 23, 40, 31, 648, DateTimeKind.Local).AddTicks(3840) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 4, 3, "details of prescription_medicament nr 3", 300 });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 38, 48, 612, DateTimeKind.Local).AddTicks(2420), new DateTime(2021, 8, 11, 23, 38, 48, 612, DateTimeKind.Local).AddTicks(4299) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 38, 48, 612, DateTimeKind.Local).AddTicks(7354), new DateTime(2021, 10, 11, 23, 38, 48, 612, DateTimeKind.Local).AddTicks(7381) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 38, 48, 612, DateTimeKind.Local).AddTicks(7388), new DateTime(2021, 7, 11, 23, 38, 48, 612, DateTimeKind.Local).AddTicks(7391) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 4,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 38, 48, 612, DateTimeKind.Local).AddTicks(7400), new DateTime(2022, 2, 11, 23, 38, 48, 612, DateTimeKind.Local).AddTicks(7405) });
        }
    }
}
