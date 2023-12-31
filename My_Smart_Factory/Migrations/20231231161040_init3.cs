using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Smart_Factory.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspEquipRecordModels_SpecModels_SpecId",
                table: "InspEquipRecordModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdInspectionRecords_SpecModels_SpecId",
                table: "ProdInspectionRecords");

            migrationBuilder.DropIndex(
                name: "IX_ProdInspectionRecords_SpecId",
                table: "ProdInspectionRecords");

            migrationBuilder.DropIndex(
                name: "IX_InspEquipRecordModels_SpecId",
                table: "InspEquipRecordModels");

            migrationBuilder.DropColumn(
                name: "SpecId",
                table: "ProdInspectionRecords");

            migrationBuilder.DropColumn(
                name: "SpecId",
                table: "InspEquipRecordModels");

            migrationBuilder.AddColumn<int>(
                name: "CurrentWorkQuantity",
                table: "WorkOrderModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QRURL",
                table: "WorkOrderModels",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "SpecId",
                table: "WorkOrderModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserIdentityId",
                table: "WorkOrderModels",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkOrderDate",
                table: "WorkOrderModels",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkOrderNumber",
                table: "WorkOrderModels",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "WorkQuantity",
                table: "WorkOrderModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkStatus",
                table: "WorkOrderModels",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderModels_SpecId",
                table: "WorkOrderModels",
                column: "SpecId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderModels_UserIdentityId",
                table: "WorkOrderModels",
                column: "UserIdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderModels_AspNetUsers_UserIdentityId",
                table: "WorkOrderModels",
                column: "UserIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderModels_SpecModels_SpecId",
                table: "WorkOrderModels",
                column: "SpecId",
                principalTable: "SpecModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderModels_AspNetUsers_UserIdentityId",
                table: "WorkOrderModels");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderModels_SpecModels_SpecId",
                table: "WorkOrderModels");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrderModels_SpecId",
                table: "WorkOrderModels");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrderModels_UserIdentityId",
                table: "WorkOrderModels");

            migrationBuilder.DropColumn(
                name: "CurrentWorkQuantity",
                table: "WorkOrderModels");

            migrationBuilder.DropColumn(
                name: "QRURL",
                table: "WorkOrderModels");

            migrationBuilder.DropColumn(
                name: "SpecId",
                table: "WorkOrderModels");

            migrationBuilder.DropColumn(
                name: "UserIdentityId",
                table: "WorkOrderModels");

            migrationBuilder.DropColumn(
                name: "WorkOrderDate",
                table: "WorkOrderModels");

            migrationBuilder.DropColumn(
                name: "WorkOrderNumber",
                table: "WorkOrderModels");

            migrationBuilder.DropColumn(
                name: "WorkQuantity",
                table: "WorkOrderModels");

            migrationBuilder.DropColumn(
                name: "WorkStatus",
                table: "WorkOrderModels");

            migrationBuilder.AddColumn<int>(
                name: "SpecId",
                table: "ProdInspectionRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecId",
                table: "InspEquipRecordModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProdInspectionRecords_SpecId",
                table: "ProdInspectionRecords",
                column: "SpecId");

            migrationBuilder.CreateIndex(
                name: "IX_InspEquipRecordModels_SpecId",
                table: "InspEquipRecordModels",
                column: "SpecId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspEquipRecordModels_SpecModels_SpecId",
                table: "InspEquipRecordModels",
                column: "SpecId",
                principalTable: "SpecModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdInspectionRecords_SpecModels_SpecId",
                table: "ProdInspectionRecords",
                column: "SpecId",
                principalTable: "SpecModels",
                principalColumn: "Id");
        }
    }
}
