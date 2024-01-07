using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class MakesLocalizedInfosUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LocalizedEmotionInfo_EmotionId",
                table: "LocalizedEmotionInfo");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "153dbfe4-1b83-49ce-b7f7-41612d94a150",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e36014bf-7df1-46e6-9001-445fe4bacc9d", "fdf2d07a-0e0f-4f7e-995b-d6e13bdcc145" });

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedEmotionInfo_EmotionId_Lcid",
                table: "LocalizedEmotionInfo",
                columns: new[] { "EmotionId", "Lcid" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LocalizedEmotionInfo_EmotionId_Lcid",
                table: "LocalizedEmotionInfo");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "153dbfe4-1b83-49ce-b7f7-41612d94a150",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "14078ed8-ee9e-41b7-b702-d8d5a03eeeeb", "a91c9c82-e72d-4ac1-894c-40a7dc7ed0e0" });

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedEmotionInfo_EmotionId",
                table: "LocalizedEmotionInfo",
                column: "EmotionId");
        }
    }
}
