using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddsAppRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0794c54b-7b02-415d-a267-6a9c21b39bd3", null, "Editor", "EDITOR" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", null, "Administrator", "ADMINISTRATOR" },
                    { "e738ea63-6593-4098-b0b5-a42c84bfdc66", null, "HeadEditor", "HEADEDITOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "153dbfe4-1b83-49ce-b7f7-41612d94a150", 0, "0df6785a-e0a3-40d1-a0bc-7a5a113a014e", "timo_weike@gmx.de", true, false, null, "TIMO_WEIKE@GMX.DE", "TIMO_WEIKE@GMX.DE", "AQAAAAIAAYagAAAAEBHi9XJZFbM7BHe5DenM+akwUKWspGnBUx+TJFXOQvVJ1iTNuNMQWyaOQfb3VIejdQ==", null, false, "0e8f6c2b-f8fa-4d85-a955-5ad40c656cf6", false, "timo_weike@gmx.de" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "153dbfe4-1b83-49ce-b7f7-41612d94a150" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0794c54b-7b02-415d-a267-6a9c21b39bd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e738ea63-6593-4098-b0b5-a42c84bfdc66");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "153dbfe4-1b83-49ce-b7f7-41612d94a150" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "153dbfe4-1b83-49ce-b7f7-41612d94a150");
        }
    }
}
