using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Smart_Factory.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FullInspEquipRecordVo");

            migrationBuilder.DropTable(
                name: "FullInspProdRecordVo");

            migrationBuilder.DropTable(
                name: "InspEquipSettingRecordDto");

            migrationBuilder.DropTable(
                name: "InspProdRecordDto");

            migrationBuilder.DropTable(
                name: "FullInspRecordDto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FullInspEquipRecordVo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Accuracy = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ETR = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    IES = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    InspEquipName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InspectionDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ProdName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpecIES = table.Column<decimal>(type: "decimal(65,30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullInspEquipRecordVo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FullInspProdRecordVo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Accuracy = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ETR = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    InspectionDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsPassed = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    MeasuredValue = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ProdCtrlNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProdName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpecIES = table.Column<decimal>(type: "decimal(65,30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullInspProdRecordVo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FullInspRecordDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullInspeNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkOrderNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullInspRecordDto", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InspEquipSettingRecordDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullInspNo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullInspRecordDtoId = table.Column<int>(type: "int", nullable: true),
                    IES = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    InspEquipName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InspSpecName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InspectionDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspEquipSettingRecordDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspEquipSettingRecordDto_FullInspRecordDto_FullInspRecordDt~",
                        column: x => x.FullInspRecordDtoId,
                        principalTable: "FullInspRecordDto",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InspProdRecordDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullInspNo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullInspRecordDtoId = table.Column<int>(type: "int", nullable: true),
                    InspSpecName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InspectionDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    MeasuredValue = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ProdCtrlNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspProdRecordDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspProdRecordDto_FullInspRecordDto_FullInspRecordDtoId",
                        column: x => x.FullInspRecordDtoId,
                        principalTable: "FullInspRecordDto",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_InspEquipSettingRecordDto_FullInspRecordDtoId",
                table: "InspEquipSettingRecordDto",
                column: "FullInspRecordDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_InspProdRecordDto_FullInspRecordDtoId",
                table: "InspProdRecordDto",
                column: "FullInspRecordDtoId");
        }
    }
}
