using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Smart_Factory.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspEquipRecordModels_FullInspectionRecords_FullInspectionMo~",
                table: "InspEquipRecordModels");

            migrationBuilder.DropForeignKey(
                name: "FK_InspEquipRecordModels_InspEquipModels_InspEquipId",
                table: "InspEquipRecordModels");

            migrationBuilder.DropForeignKey(
                name: "FK_InspEquipRecordModels_SpecModels_InspSpecId",
                table: "InspEquipRecordModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdInspectionRecords_FullInspectionRecords_FullInspectionMo~",
                table: "ProdInspectionRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdInspectionRecords_InspEquipModels_InspEquipId",
                table: "ProdInspectionRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdInspectionRecords_ProdCtrlNoModels_ProdCtrlNoId",
                table: "ProdInspectionRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecModels_InspEquipModels_InspEquipId",
                table: "SpecModels");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecModels_ProdInfoModels_ProdInfoId",
                table: "SpecModels");

            migrationBuilder.DropTable(
                name: "FullInspectionRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecModels",
                table: "SpecModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdInspectionRecords",
                table: "ProdInspectionRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspEquipRecordModels",
                table: "InspEquipRecordModels");

            migrationBuilder.RenameTable(
                name: "SpecModels",
                newName: "InspSpecModels");

            migrationBuilder.RenameTable(
                name: "ProdInspectionRecords",
                newName: "InspProdRecordModels");

            migrationBuilder.RenameTable(
                name: "InspEquipRecordModels",
                newName: "InspEquipSettingRecordModels");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "ProdCtrlNoModels",
                newName: "ProdCtrlNo");

            migrationBuilder.RenameIndex(
                name: "IX_SpecModels_ProdInfoId",
                table: "InspSpecModels",
                newName: "IX_InspSpecModels_ProdInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_SpecModels_InspEquipId",
                table: "InspSpecModels",
                newName: "IX_InspSpecModels_InspEquipId");

            migrationBuilder.RenameColumn(
                name: "FullInspectionModelId",
                table: "InspProdRecordModels",
                newName: "FullInspRecordModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdInspectionRecords_ProdCtrlNoId",
                table: "InspProdRecordModels",
                newName: "IX_InspProdRecordModels_ProdCtrlNoId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdInspectionRecords_InspEquipId",
                table: "InspProdRecordModels",
                newName: "IX_InspProdRecordModels_InspEquipId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdInspectionRecords_FullInspectionModelId",
                table: "InspProdRecordModels",
                newName: "IX_InspProdRecordModels_FullInspRecordModelId");

            migrationBuilder.RenameColumn(
                name: "FullInspectionModelId",
                table: "InspEquipSettingRecordModels",
                newName: "FullInspRecordModelId");

            migrationBuilder.RenameIndex(
                name: "IX_InspEquipRecordModels_InspSpecId",
                table: "InspEquipSettingRecordModels",
                newName: "IX_InspEquipSettingRecordModels_InspSpecId");

            migrationBuilder.RenameIndex(
                name: "IX_InspEquipRecordModels_InspEquipId",
                table: "InspEquipSettingRecordModels",
                newName: "IX_InspEquipSettingRecordModels_InspEquipId");

            migrationBuilder.RenameIndex(
                name: "IX_InspEquipRecordModels_FullInspectionModelId",
                table: "InspEquipSettingRecordModels",
                newName: "IX_InspEquipSettingRecordModels_FullInspRecordModelId");

            migrationBuilder.AlterColumn<int>(
                name: "ProdInfoId",
                table: "InspSpecModels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "InspSpecName",
                table: "InspSpecModels",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspSpecModels",
                table: "InspSpecModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspProdRecordModels",
                table: "InspProdRecordModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspEquipSettingRecordModels",
                table: "InspEquipSettingRecordModels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FullInspRecordModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FullInspectionNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullInspRecordModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FullInspRecordModels_WorkOrderModels_Id",
                        column: x => x.Id,
                        principalTable: "WorkOrderModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_InspEquipSettingRecordModels_FullInspRecordModels_FullInspRe~",
                table: "InspEquipSettingRecordModels",
                column: "FullInspRecordModelId",
                principalTable: "FullInspRecordModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspEquipSettingRecordModels_InspEquipModels_InspEquipId",
                table: "InspEquipSettingRecordModels",
                column: "InspEquipId",
                principalTable: "InspEquipModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspEquipSettingRecordModels_InspSpecModels_InspSpecId",
                table: "InspEquipSettingRecordModels",
                column: "InspSpecId",
                principalTable: "InspSpecModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspProdRecordModels_FullInspRecordModels_FullInspRecordMode~",
                table: "InspProdRecordModels",
                column: "FullInspRecordModelId",
                principalTable: "FullInspRecordModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspProdRecordModels_InspEquipModels_InspEquipId",
                table: "InspProdRecordModels",
                column: "InspEquipId",
                principalTable: "InspEquipModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspProdRecordModels_ProdCtrlNoModels_ProdCtrlNoId",
                table: "InspProdRecordModels",
                column: "ProdCtrlNoId",
                principalTable: "ProdCtrlNoModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspSpecModels_InspEquipModels_InspEquipId",
                table: "InspSpecModels",
                column: "InspEquipId",
                principalTable: "InspEquipModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspSpecModels_ProdInfoModels_ProdInfoId",
                table: "InspSpecModels",
                column: "ProdInfoId",
                principalTable: "ProdInfoModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspEquipSettingRecordModels_FullInspRecordModels_FullInspRe~",
                table: "InspEquipSettingRecordModels");

            migrationBuilder.DropForeignKey(
                name: "FK_InspEquipSettingRecordModels_InspEquipModels_InspEquipId",
                table: "InspEquipSettingRecordModels");

            migrationBuilder.DropForeignKey(
                name: "FK_InspEquipSettingRecordModels_InspSpecModels_InspSpecId",
                table: "InspEquipSettingRecordModels");

            migrationBuilder.DropForeignKey(
                name: "FK_InspProdRecordModels_FullInspRecordModels_FullInspRecordMode~",
                table: "InspProdRecordModels");

            migrationBuilder.DropForeignKey(
                name: "FK_InspProdRecordModels_InspEquipModels_InspEquipId",
                table: "InspProdRecordModels");

            migrationBuilder.DropForeignKey(
                name: "FK_InspProdRecordModels_ProdCtrlNoModels_ProdCtrlNoId",
                table: "InspProdRecordModels");

            migrationBuilder.DropForeignKey(
                name: "FK_InspSpecModels_InspEquipModels_InspEquipId",
                table: "InspSpecModels");

            migrationBuilder.DropForeignKey(
                name: "FK_InspSpecModels_ProdInfoModels_ProdInfoId",
                table: "InspSpecModels");

            migrationBuilder.DropTable(
                name: "FullInspRecordModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspSpecModels",
                table: "InspSpecModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspProdRecordModels",
                table: "InspProdRecordModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspEquipSettingRecordModels",
                table: "InspEquipSettingRecordModels");

            migrationBuilder.DropColumn(
                name: "InspSpecName",
                table: "InspSpecModels");

            migrationBuilder.RenameTable(
                name: "InspSpecModels",
                newName: "SpecModels");

            migrationBuilder.RenameTable(
                name: "InspProdRecordModels",
                newName: "ProdInspectionRecords");

            migrationBuilder.RenameTable(
                name: "InspEquipSettingRecordModels",
                newName: "InspEquipRecordModels");

            migrationBuilder.RenameColumn(
                name: "ProdCtrlNo",
                table: "ProdCtrlNoModels",
                newName: "Number");

            migrationBuilder.RenameIndex(
                name: "IX_InspSpecModels_ProdInfoId",
                table: "SpecModels",
                newName: "IX_SpecModels_ProdInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_InspSpecModels_InspEquipId",
                table: "SpecModels",
                newName: "IX_SpecModels_InspEquipId");

            migrationBuilder.RenameColumn(
                name: "FullInspRecordModelId",
                table: "ProdInspectionRecords",
                newName: "FullInspectionModelId");

            migrationBuilder.RenameIndex(
                name: "IX_InspProdRecordModels_ProdCtrlNoId",
                table: "ProdInspectionRecords",
                newName: "IX_ProdInspectionRecords_ProdCtrlNoId");

            migrationBuilder.RenameIndex(
                name: "IX_InspProdRecordModels_InspEquipId",
                table: "ProdInspectionRecords",
                newName: "IX_ProdInspectionRecords_InspEquipId");

            migrationBuilder.RenameIndex(
                name: "IX_InspProdRecordModels_FullInspRecordModelId",
                table: "ProdInspectionRecords",
                newName: "IX_ProdInspectionRecords_FullInspectionModelId");

            migrationBuilder.RenameColumn(
                name: "FullInspRecordModelId",
                table: "InspEquipRecordModels",
                newName: "FullInspectionModelId");

            migrationBuilder.RenameIndex(
                name: "IX_InspEquipSettingRecordModels_InspSpecId",
                table: "InspEquipRecordModels",
                newName: "IX_InspEquipRecordModels_InspSpecId");

            migrationBuilder.RenameIndex(
                name: "IX_InspEquipSettingRecordModels_InspEquipId",
                table: "InspEquipRecordModels",
                newName: "IX_InspEquipRecordModels_InspEquipId");

            migrationBuilder.RenameIndex(
                name: "IX_InspEquipSettingRecordModels_FullInspRecordModelId",
                table: "InspEquipRecordModels",
                newName: "IX_InspEquipRecordModels_FullInspectionModelId");

            migrationBuilder.AlterColumn<int>(
                name: "ProdInfoId",
                table: "SpecModels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecModels",
                table: "SpecModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdInspectionRecords",
                table: "ProdInspectionRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspEquipRecordModels",
                table: "InspEquipRecordModels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FullInspectionRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FullInspectionNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullInspectionRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FullInspectionRecords_WorkOrderModels_Id",
                        column: x => x.Id,
                        principalTable: "WorkOrderModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_InspEquipRecordModels_FullInspectionRecords_FullInspectionMo~",
                table: "InspEquipRecordModels",
                column: "FullInspectionModelId",
                principalTable: "FullInspectionRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspEquipRecordModels_InspEquipModels_InspEquipId",
                table: "InspEquipRecordModels",
                column: "InspEquipId",
                principalTable: "InspEquipModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspEquipRecordModels_SpecModels_InspSpecId",
                table: "InspEquipRecordModels",
                column: "InspSpecId",
                principalTable: "SpecModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdInspectionRecords_FullInspectionRecords_FullInspectionMo~",
                table: "ProdInspectionRecords",
                column: "FullInspectionModelId",
                principalTable: "FullInspectionRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdInspectionRecords_InspEquipModels_InspEquipId",
                table: "ProdInspectionRecords",
                column: "InspEquipId",
                principalTable: "InspEquipModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdInspectionRecords_ProdCtrlNoModels_ProdCtrlNoId",
                table: "ProdInspectionRecords",
                column: "ProdCtrlNoId",
                principalTable: "ProdCtrlNoModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecModels_InspEquipModels_InspEquipId",
                table: "SpecModels",
                column: "InspEquipId",
                principalTable: "InspEquipModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecModels_ProdInfoModels_ProdInfoId",
                table: "SpecModels",
                column: "ProdInfoId",
                principalTable: "ProdInfoModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
