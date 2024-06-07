using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cwiczenia_6.Migrations
{
    public partial class alteredData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Date", "DueDate", "IdDoctor" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 38, 48, 612, DateTimeKind.Local).AddTicks(7388), new DateTime(2021, 7, 11, 23, 38, 48, 612, DateTimeKind.Local).AddTicks(7391), 1 });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 4,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 38, 48, 612, DateTimeKind.Local).AddTicks(7400), new DateTime(2022, 2, 11, 23, 38, 48, 612, DateTimeKind.Local).AddTicks(7405) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 32, 21, 133, DateTimeKind.Local).AddTicks(788), new DateTime(2021, 8, 11, 23, 32, 21, 133, DateTimeKind.Local).AddTicks(1992) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 32, 21, 133, DateTimeKind.Local).AddTicks(4528), new DateTime(2021, 10, 11, 23, 32, 21, 133, DateTimeKind.Local).AddTicks(4558) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3,
                columns: new[] { "Date", "DueDate", "IdDoctor" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 32, 21, 133, DateTimeKind.Local).AddTicks(4566), new DateTime(2021, 7, 11, 23, 32, 21, 133, DateTimeKind.Local).AddTicks(4571), 3 });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 4,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 32, 21, 133, DateTimeKind.Local).AddTicks(4576), new DateTime(2022, 2, 11, 23, 32, 21, 133, DateTimeKind.Local).AddTicks(4580) });
        }
    }
}
