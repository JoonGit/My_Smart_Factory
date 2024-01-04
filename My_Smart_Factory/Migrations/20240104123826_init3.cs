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
                name: "FK_InspEquipSettingRecordModels_FullInspRecordModels_FullInspRe~",
                table: "InspEquipSettingRecordModels");

            migrationBuilder.DropForeignKey(
                name: "FK_InspProdRecordModels_FullInspRecordModels_FullInspRecordMode~",
                table: "InspProdRecordModels");

            migrationBuilder.DropIndex(
                name: "IX_InspEquipSettingRecordModels_FullInspRecordModelId",
                table: "InspEquipSettingRecordModels");

            migrationBuilder.DropColumn(
                name: "FullInspRecordModelId",
                table: "InspEquipSettingRecordModels");

            migrationBuilder.RenameColumn(
                name: "WorkStatus",
                table: "WorkOrderModels",
                newName: "WorkOrderStatus");

            migrationBuilder.RenameColumn(
                name: "WorkOrderNumber",
                table: "WorkOrderModels",
                newName: "WorkOrderNo");

            migrationBuilder.RenameColumn(
                name: "FullInspRecordModelId",
                table: "InspProdRecordModels",
                newName: "FullInspRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_InspProdRecordModels_FullInspRecordModelId",
                table: "InspProdRecordModels",
                newName: "IX_InspProdRecordModels_FullInspRecordId");

            migrationBuilder.RenameColumn(
                name: "FullInspectionNumber",
                table: "FullInspRecordModels",
                newName: "FullInspNo");

            migrationBuilder.AddColumn<int>(
                name: "FullInspRecordId",
                table: "InspEquipSettingRecordModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InspEquipSettingRecordModels_FullInspRecordId",
                table: "InspEquipSettingRecordModels",
                column: "FullInspRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspEquipSettingRecordModels_FullInspRecordModels_FullInspRe~",
                table: "InspEquipSettingRecordModels",
                column: "FullInspRecordId",
                principalTable: "FullInspRecordModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspProdRecordModels_FullInspRecordModels_FullInspRecordId",
                table: "InspProdRecordModels",
                column: "FullInspRecordId",
                principalTable: "FullInspRecordModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspEquipSettingRecordModels_FullInspRecordModels_FullInspRe~",
                table: "InspEquipSettingRecordModels");

            migrationBuilder.DropForeignKey(
                name: "FK_InspProdRecordModels_FullInspRecordModels_FullInspRecordId",
                table: "InspProdRecordModels");

            migrationBuilder.DropIndex(
                name: "IX_InspEquipSettingRecordModels_FullInspRecordId",
                table: "InspEquipSettingRecordModels");

            migrationBuilder.DropColumn(
                name: "FullInspRecordId",
                table: "InspEquipSettingRecordModels");

            migrationBuilder.RenameColumn(
                name: "WorkOrderStatus",
                table: "WorkOrderModels",
                newName: "WorkStatus");

            migrationBuilder.RenameColumn(
                name: "WorkOrderNo",
                table: "WorkOrderModels",
                newName: "WorkOrderNumber");

            migrationBuilder.RenameColumn(
                name: "FullInspRecordId",
                table: "InspProdRecordModels",
                newName: "FullInspRecordModelId");

            migrationBuilder.RenameIndex(
                name: "IX_InspProdRecordModels_FullInspRecordId",
                table: "InspProdRecordModels",
                newName: "IX_InspProdRecordModels_FullInspRecordModelId");

            migrationBuilder.RenameColumn(
                name: "FullInspNo",
                table: "FullInspRecordModels",
                newName: "FullInspectionNumber");

            migrationBuilder.AddColumn<int>(
                name: "FullInspRecordModelId",
                table: "InspEquipSettingRecordModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspEquipSettingRecordModels_FullInspRecordModelId",
                table: "InspEquipSettingRecordModels",
                column: "FullInspRecordModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspEquipSettingRecordModels_FullInspRecordModels_FullInspRe~",
                table: "InspEquipSettingRecordModels",
                column: "FullInspRecordModelId",
                principalTable: "FullInspRecordModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspProdRecordModels_FullInspRecordModels_FullInspRecordMode~",
                table: "InspProdRecordModels",
                column: "FullInspRecordModelId",
                principalTable: "FullInspRecordModels",
                principalColumn: "Id");
        }
    }
}
