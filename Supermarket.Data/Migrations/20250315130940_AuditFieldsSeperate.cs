using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Supermarket.Data.Migrations
{
    /// <inheritdoc />
    public partial class AuditFieldsSeperate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01d9034a-68ed-404a-b263-685456ff17e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39606c55-fab6-405c-849c-2e97e8a892f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ee33dd4-3b03-4b20-9c58-b22d33850910");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0dc0a96-ae65-4c70-9b7c-4ab9eb49651f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c510a92c-5d5d-4311-ba1d-4f4a0ea1c080");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProductCategories",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ProductCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "ProductCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ProductCategories",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ProductCategories");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01d9034a-68ed-404a-b263-685456ff17e8", null, "Supervisor", "SUPERVISOR" },
                    { "39606c55-fab6-405c-849c-2e97e8a892f4", null, "Customer", "CUSTOMER" },
                    { "6ee33dd4-3b03-4b20-9c58-b22d33850910", null, "Moderator", "MODERATOR" },
                    { "c0dc0a96-ae65-4c70-9b7c-4ab9eb49651f", null, "Admin", "ADMIN" },
                    { "c510a92c-5d5d-4311-ba1d-4f4a0ea1c080", null, "Employee", "EMPLOYEE" }
                });
        }
    }
}
