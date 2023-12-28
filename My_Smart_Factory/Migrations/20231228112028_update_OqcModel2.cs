using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Smart_Factory.Migrations
{
    /// <inheritdoc />
    public partial class update_OqcModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OqcModels_AspNetUsers_ConfirmorId",
                table: "OqcModels");

            migrationBuilder.DropForeignKey(
                name: "FK_OqcModels_AspNetUsers_InspectorId",
                table: "OqcModels");

            migrationBuilder.AlterColumn<string>(
                name: "ProcessName",
                table: "OqcModels",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "InspectorId",
                table: "OqcModels",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EtcInfo",
                table: "OqcModels",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ConfirmorId",
                table: "OqcModels",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_OqcModels_AspNetUsers_ConfirmorId",
                table: "OqcModels",
                column: "ConfirmorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OqcModels_AspNetUsers_InspectorId",
                table: "OqcModels",
                column: "InspectorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
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

            migrationBuilder.UpdateData(
                table: "OqcModels",
                keyColumn: "ProcessName",
                keyValue: null,
                column: "ProcessName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProcessName",
                table: "OqcModels",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "OqcModels",
                keyColumn: "InspectorId",
                keyValue: null,
                column: "InspectorId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "InspectorId",
                table: "OqcModels",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "OqcModels",
                keyColumn: "EtcInfo",
                keyValue: null,
                column: "EtcInfo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "EtcInfo",
                table: "OqcModels",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "OqcModels",
                keyColumn: "ConfirmorId",
                keyValue: null,
                column: "ConfirmorId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ConfirmorId",
                table: "OqcModels",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
    }
}
