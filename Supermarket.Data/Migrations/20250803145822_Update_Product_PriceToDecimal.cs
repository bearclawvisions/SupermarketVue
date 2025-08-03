using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Supermarket.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_Product_PriceToDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c76f046-f3d3-4da5-91c6-bc360d24c8d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50c29b5d-e725-42e2-8d96-0ac350cc72e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76693f17-9f51-4e7c-be23-25bd8a90abf9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f07e463-e8ee-4c2d-881d-ad30a6049353");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3dc867f-1da6-4328-a544-9d4ecc4fe5b5");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c76f046-f3d3-4da5-91c6-bc360d24c8d9", null, "Customer", "CUSTOMER" },
                    { "50c29b5d-e725-42e2-8d96-0ac350cc72e6", null, "Supervisor", "SUPERVISOR" },
                    { "76693f17-9f51-4e7c-be23-25bd8a90abf9", null, "Admin", "ADMIN" },
                    { "7f07e463-e8ee-4c2d-881d-ad30a6049353", null, "Employee", "EMPLOYEE" },
                    { "f3dc867f-1da6-4328-a544-9d4ecc4fe5b5", null, "Moderator", "MODERATOR" }
                });
        }
    }
}
