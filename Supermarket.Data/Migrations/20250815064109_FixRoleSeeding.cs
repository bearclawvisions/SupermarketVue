using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Supermarket.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixRoleSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11a5cb20-dbf6-4e54-b914-3016b23893ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39afddaf-6db7-467b-b577-8934b0f79f03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47933cb4-e5f5-4b24-942b-4d45936ced97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f2683df-5513-49fe-9d34-1b95331264fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf7245d2-6b20-40bf-a4ea-c6fd82e8a8ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eda75243-aa50-472a-b942-1ac85105df3d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "61926441-8fa0-4d2b-85a3-91a4ab95e2d0", null, "Moderator", "MODERATOR" },
                    { "6c33cde8-cdf1-4aca-a8f0-0ab43903000e", null, "Admin", "ADMIN" },
                    { "83f1e13a-0a0a-447c-9007-5e6a07676c0d", null, "Customer", "CUSTOMER" },
                    { "ec79da32-4d4d-48ae-be26-fbee5ec56f93", null, "Supervisor", "SUPERVISOR" },
                    { "fa174c70-8bff-4b6b-94a1-d567f8d0b3d4", null, "Employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61926441-8fa0-4d2b-85a3-91a4ab95e2d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c33cde8-cdf1-4aca-a8f0-0ab43903000e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83f1e13a-0a0a-447c-9007-5e6a07676c0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec79da32-4d4d-48ae-be26-fbee5ec56f93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa174c70-8bff-4b6b-94a1-d567f8d0b3d4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11a5cb20-dbf6-4e54-b914-3016b23893ae", null, "Moderator", "MODERATOR" },
                    { "39afddaf-6db7-467b-b577-8934b0f79f03", null, "None", "NONE" },
                    { "47933cb4-e5f5-4b24-942b-4d45936ced97", null, "Supervisor", "SUPERVISOR" },
                    { "7f2683df-5513-49fe-9d34-1b95331264fa", null, "Employee", "EMPLOYEE" },
                    { "bf7245d2-6b20-40bf-a4ea-c6fd82e8a8ba", null, "Admin", "ADMIN" },
                    { "eda75243-aa50-472a-b942-1ac85105df3d", null, "Customer", "CUSTOMER" }
                });
        }
    }
}
