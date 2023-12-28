using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Smart_Factory.Migrations
{
    /// <inheritdoc />
    public partial class update_OqcModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmor",
                table: "OqcModels");

            migrationBuilder.DropColumn(
                name: "Inspector",
                table: "OqcModels");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmorId",
                table: "OqcModels",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "InspectorId",
                table: "OqcModels",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OqcModels_ConfirmorId",
                table: "OqcModels",
                column: "ConfirmorId");

            migrationBuilder.CreateIndex(
                name: "IX_OqcModels_InspectorId",
                table: "OqcModels",
                column: "InspectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_OqcModels_AspNetUsers_ConfirmorId",
                table: "OqcModels",
                column: "ConfirmorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OqcModels_AspNetUsers_InspectorId",
                table: "OqcModels",
                column: "InspectorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OqcModels_AspNetUsers_ConfirmorId",
                table: "OqcModels");

            migrationBuilder.DropForeignKey(
                name: "FK_OqcModels_AspNetUsers_InspectorId",
                table: "OqcModels");

            migrationBuilder.DropIndex(
                name: "IX_OqcModels_ConfirmorId",
                table: "OqcModels");

            migrationBuilder.DropIndex(
                name: "IX_OqcModels_InspectorId",
                table: "OqcModels");

            migrationBuilder.DropColumn(
                name: "ConfirmorId",
                table: "OqcModels");

            migrationBuilder.DropColumn(
                name: "InspectorId",
                table: "OqcModels");

            migrationBuilder.AddColumn<string>(
                name: "Confirmor",
                table: "OqcModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Inspector",
                table: "OqcModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
