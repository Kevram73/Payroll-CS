using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payroll.Migrations
{
    /// <inheritdoc />
    public partial class AddAttendancTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eee1cedd-7878-44cf-8249-b59e95a6cce1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8026594a-b279-415b-8955-31fdc7cf4fd6", 0, "909ed3fd-2329-4ca8-b90a-8729de68d0a3", "kevram@payroll.com", true, "Kevin", "Brown", false, null, "KEVRAM@PAYROLL.COM", "KEVRAM", "AQAAAAIAAYagAAAAEJAhKlXn8NhjugsSl9nwy4ooSuqtjpe1k1y5e92/2QgXwmOfz+HjZZXfkEV8mLecQQ==", null, false, "f44258c2-ded3-420c-b863-c599e4fb3816", false, "kevram" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8026594a-b279-415b-8955-31fdc7cf4fd6");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eee1cedd-7878-44cf-8249-b59e95a6cce1", 0, "250617a2-72d3-468b-904a-60218b7a39ab", "kevram@payroll.com", true, "Kevin", "Brown", false, null, "KEVRAM@PAYROLL.COM", "KEVRAM", "AQAAAAIAAYagAAAAEBZtdx/9ymOn01NyvI9uc7S8MvKbZMKcz5H4jwDEwsvIwp6agk1N9/4Uq01TrV433A==", null, false, "00aff572-5a5a-45b9-a75f-980454500c1c", false, "kevram" });
        }
    }
}
