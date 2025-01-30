using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payroll.Migrations
{
    /// <inheritdoc />
    public partial class FirstUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "a83d40b0-bccd-4974-ba36-4d163da10aba", "kevram@payroll.com", true, "Kevin", "Brown", false, null, "KEVRAM@PAYROLL.COM", "KEVRAM", "AQAAAAIAAYagAAAAEN/hBlJxSwMiGg3f1xK2nF0bWkTNJEyHvsfNuA11XDS2gpSrbH3Fc0ant5ksUCXyTg==", null, false, "", false, "kevram" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
