using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PaymentSystem.Migrations
{
    /// <inheritdoc />
    public partial class seedingDataForPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "ID", "Amount", "PaymentDate", "UserID" },
                values: new object[,]
                {
                    { 7, 200m, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 8, 6000m, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "ID",
                keyValue: 8);
        }
    }
}
