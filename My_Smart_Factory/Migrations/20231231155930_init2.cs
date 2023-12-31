using System;
using Microsoft.EntityFrameworkCore.Metadata;
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
            migrationBuilder.DropTable(
                name: "OqcModels");

            migrationBuilder.DropTable(
                name: "PpsModels");

            migrationBuilder.DropTable(
                name: "PiModels");

            migrationBuilder.CreateTable(
                name: "CaseLotModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LotNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unit = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseLotModels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InspEquipModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unit = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspEquipModels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OutgoingInspModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Controlnumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProcessName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InspectionTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InspectionResult = table.Column<int>(type: "int", nullable: false),
                    InspectorId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConfirmorId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CapacityDefect = table.Column<int>(type: "int", nullable: false),
                    LossDefect = table.Column<int>(type: "int", nullable: false),
                    BubbleDefect = table.Column<int>(type: "int", nullable: false),
                    CenterDefect = table.Column<int>(type: "int", nullable: false),
                    InnerDiameterDefect = table.Column<int>(type: "int", nullable: false),
                    MarkDefect = table.Column<int>(type: "int", nullable: false),
                    CaseDefect = table.Column<int>(type: "int", nullable: false),
                    EpoxyDefect = table.Column<int>(type: "int", nullable: false),
                    EtcDefect = table.Column<int>(type: "int", nullable: false),
                    EtcInfo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutgoingInspModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutgoingInspModels_AspNetUsers_ConfirmorId",
                        column: x => x.ConfirmorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OutgoingInspModels_AspNetUsers_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdCtrlNoModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ControlNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginOfProduction = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdCtrlNoModels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdInfoModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ControlNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Specification = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LotNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdInfoModels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkOrderModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderModels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpecModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InspEquipId = table.Column<int>(type: "int", nullable: true),
                    IES = table.Column<double>(type: "double", nullable: true),
                    ETR = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecModels_InspEquipModels_InspEquipId",
                        column: x => x.InspEquipId,
                        principalTable: "InspEquipModels",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProcessStatusModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OperatorId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DefectiveQuantity = table.Column<int>(type: "int", nullable: false),
                    ProdInfoModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessStatusModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessStatusModels_AspNetUsers_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProcessStatusModels_ProdInfoModels_ProdInfoModelId",
                        column: x => x.ProdInfoModelId,
                        principalTable: "ProdInfoModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InspEquipRecordModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpecId = table.Column<int>(type: "int", nullable: true),
                    IES = table.Column<double>(type: "double", nullable: true),
                    Accuracy = table.Column<double>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspEquipRecordModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspEquipRecordModels_SpecModels_SpecId",
                        column: x => x.SpecId,
                        principalTable: "SpecModels",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FullInspectionRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullInspectionNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkOrderId = table.Column<int>(type: "int", nullable: true),
                    InspectionDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    InspEquipRecordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullInspectionRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FullInspectionRecords_InspEquipRecordModels_InspEquipRecordId",
                        column: x => x.InspEquipRecordId,
                        principalTable: "InspEquipRecordModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FullInspectionRecords_WorkOrderModels_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrderModels",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdInspectionRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WorkOrderId = table.Column<int>(type: "int", nullable: true),
                    ProdCtrlNoId = table.Column<int>(type: "int", nullable: true),
                    SpecId = table.Column<int>(type: "int", nullable: true),
                    Accuracy = table.Column<double>(type: "double", nullable: true),
                    IsPassed = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    FullInspectionModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdInspectionRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdInspectionRecords_FullInspectionRecords_FullInspectionMo~",
                        column: x => x.FullInspectionModelId,
                        principalTable: "FullInspectionRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProdInspectionRecords_ProdCtrlNoModels_ProdCtrlNoId",
                        column: x => x.ProdCtrlNoId,
                        principalTable: "ProdCtrlNoModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProdInspectionRecords_SpecModels_SpecId",
                        column: x => x.SpecId,
                        principalTable: "SpecModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProdInspectionRecords_WorkOrderModels_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrderModels",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FullInspectionRecords_InspEquipRecordId",
                table: "FullInspectionRecords",
                column: "InspEquipRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_FullInspectionRecords_WorkOrderId",
                table: "FullInspectionRecords",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InspEquipRecordModels_SpecId",
                table: "InspEquipRecordModels",
                column: "SpecId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingInspModels_ConfirmorId",
                table: "OutgoingInspModels",
                column: "ConfirmorId");

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingInspModels_InspectorId",
                table: "OutgoingInspModels",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessStatusModels_OperatorId",
                table: "ProcessStatusModels",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessStatusModels_ProdInfoModelId",
                table: "ProcessStatusModels",
                column: "ProdInfoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdInspectionRecords_FullInspectionModelId",
                table: "ProdInspectionRecords",
                column: "FullInspectionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdInspectionRecords_ProdCtrlNoId",
                table: "ProdInspectionRecords",
                column: "ProdCtrlNoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdInspectionRecords_SpecId",
                table: "ProdInspectionRecords",
                column: "SpecId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdInspectionRecords_WorkOrderId",
                table: "ProdInspectionRecords",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecModels_InspEquipId",
                table: "SpecModels",
                column: "InspEquipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseLotModels");

            migrationBuilder.DropTable(
                name: "OutgoingInspModels");

            migrationBuilder.DropTable(
                name: "ProcessStatusModels");

            migrationBuilder.DropTable(
                name: "ProdInspectionRecords");

            migrationBuilder.DropTable(
                name: "ProdInfoModels");

            migrationBuilder.DropTable(
                name: "FullInspectionRecords");

            migrationBuilder.DropTable(
                name: "ProdCtrlNoModels");

            migrationBuilder.DropTable(
                name: "InspEquipRecordModels");

            migrationBuilder.DropTable(
                name: "WorkOrderModels");

            migrationBuilder.DropTable(
                name: "SpecModels");

            migrationBuilder.DropTable(
                name: "InspEquipModels");

            migrationBuilder.CreateTable(
                name: "OqcModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ConfirmorId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InspectorId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BubbleDefect = table.Column<int>(type: "int", nullable: false),
                    CapacityDefect = table.Column<int>(type: "int", nullable: false),
                    CaseDefect = table.Column<int>(type: "int", nullable: false),
                    CenterDefect = table.Column<int>(type: "int", nullable: false),
                    Controlnumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EpoxyDefect = table.Column<int>(type: "int", nullable: false),
                    EtcDefect = table.Column<int>(type: "int", nullable: false),
                    EtcInfo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InnerDiameterDefect = table.Column<int>(type: "int", nullable: false),
                    InspectionResult = table.Column<int>(type: "int", nullable: false),
                    InspectionTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LossDefect = table.Column<int>(type: "int", nullable: false),
                    MarkDefect = table.Column<int>(type: "int", nullable: false),
                    ProcessName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OqcModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OqcModels_AspNetUsers_ConfirmorId",
                        column: x => x.ConfirmorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OqcModels_AspNetUsers_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PiModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ControlNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LotNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Specification = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiModels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PpsModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OperatorId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PiModelId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DefectiveQuantity = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PpsModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PpsModels_AspNetUsers_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PpsModels_PiModels_PiModelId",
                        column: x => x.PiModelId,
                        principalTable: "PiModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OqcModels_ConfirmorId",
                table: "OqcModels",
                column: "ConfirmorId");

            migrationBuilder.CreateIndex(
                name: "IX_OqcModels_InspectorId",
                table: "OqcModels",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_PpsModels_OperatorId",
                table: "PpsModels",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PpsModels_PiModelId",
                table: "PpsModels",
                column: "PiModelId");
        }
    }
}
