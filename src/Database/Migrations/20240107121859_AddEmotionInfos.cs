using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddEmotionInfos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Emotions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EmotionDefaultComposePart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmotionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartEmotionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartValue = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmotionDefaultComposePart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmotionDefaultComposePart_Emotions_EmotionId",
                        column: x => x.EmotionId,
                        principalTable: "Emotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmotionDefaultComposePart_Emotions_PartEmotionId",
                        column: x => x.PartEmotionId,
                        principalTable: "Emotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalizedEmotionInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Lcid = table.Column<string>(type: "text", nullable: false),
                    EmotionId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocalizedName = table.Column<string>(type: "text", nullable: false),
                    LocalizedDesciption = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedEmotionInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalizedEmotionInfo_Emotions_EmotionId",
                        column: x => x.EmotionId,
                        principalTable: "Emotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDefinedComposition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmotionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartEmotionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartValue = table.Column<decimal>(type: "numeric", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDefinedComposition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDefinedComposition_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDefinedComposition_Emotions_EmotionId",
                        column: x => x.EmotionId,
                        principalTable: "Emotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDefinedComposition_Emotions_PartEmotionId",
                        column: x => x.PartEmotionId,
                        principalTable: "Emotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "153dbfe4-1b83-49ce-b7f7-41612d94a150",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "14078ed8-ee9e-41b7-b702-d8d5a03eeeeb", "a91c9c82-e72d-4ac1-894c-40a7dc7ed0e0" });

            migrationBuilder.CreateIndex(
                name: "IX_EmotionDefaultComposePart_EmotionId",
                table: "EmotionDefaultComposePart",
                column: "EmotionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmotionDefaultComposePart_PartEmotionId",
                table: "EmotionDefaultComposePart",
                column: "PartEmotionId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedEmotionInfo_EmotionId",
                table: "LocalizedEmotionInfo",
                column: "EmotionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedComposition_EmotionId",
                table: "UserDefinedComposition",
                column: "EmotionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedComposition_PartEmotionId",
                table: "UserDefinedComposition",
                column: "PartEmotionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedComposition_UserId",
                table: "UserDefinedComposition",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmotionDefaultComposePart");

            migrationBuilder.DropTable(
                name: "LocalizedEmotionInfo");

            migrationBuilder.DropTable(
                name: "UserDefinedComposition");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Emotions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "153dbfe4-1b83-49ce-b7f7-41612d94a150",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0df6785a-e0a3-40d1-a0bc-7a5a113a014e", "0e8f6c2b-f8fa-4d85-a955-5ad40c656cf6" });
        }
    }
}
