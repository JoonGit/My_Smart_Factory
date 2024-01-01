using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Smart_Factory.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                    InspEquipName = table.Column<string>(type: "longtext", nullable: true)
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
                name: "ProdInfoModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProdName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProdCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProdWeight = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdInfoModels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.ProviderKey, x.LoginProvider });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ProdCtrlNoModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProdInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdCtrlNoModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdCtrlNoModels_ProdInfoModels_ProdInfoId",
                        column: x => x.ProdInfoId,
                        principalTable: "ProdInfoModels",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpecModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProdInfoId = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_SpecModels_ProdInfoModels_ProdInfoId",
                        column: x => x.ProdInfoId,
                        principalTable: "ProdInfoModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkOrderModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WorkOrderNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkOrderDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ProdInfoId = table.Column<int>(type: "int", nullable: true),
                    UserIdentityId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkQuantity = table.Column<int>(type: "int", nullable: true),
                    WorkStatus = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentWorkQuantity = table.Column<int>(type: "int", nullable: true),
                    QRURL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrderModels_AspNetUsers_UserIdentityId",
                        column: x => x.UserIdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrderModels_ProdInfoModels_ProdInfoId",
                        column: x => x.ProdInfoId,
                        principalTable: "ProdInfoModels",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "InspEquipRecordModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InspEquipId = table.Column<int>(type: "int", nullable: true),
                    InspSpecId = table.Column<int>(type: "int", nullable: true),
                    InspectionDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IES = table.Column<double>(type: "double", nullable: true),
                    Accuracy = table.Column<double>(type: "double", nullable: true),
                    FullInspectionModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspEquipRecordModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspEquipRecordModels_FullInspectionRecords_FullInspectionMo~",
                        column: x => x.FullInspectionModelId,
                        principalTable: "FullInspectionRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspEquipRecordModels_InspEquipModels_InspEquipId",
                        column: x => x.InspEquipId,
                        principalTable: "InspEquipModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspEquipRecordModels_SpecModels_InspSpecId",
                        column: x => x.InspSpecId,
                        principalTable: "SpecModels",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdInspectionRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InspEquipId = table.Column<int>(type: "int", nullable: true),
                    ProdCtrlNoId = table.Column<int>(type: "int", nullable: true),
                    InspectionDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    MeasuredValue = table.Column<double>(type: "double", nullable: true),
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
                        name: "FK_ProdInspectionRecords_InspEquipModels_InspEquipId",
                        column: x => x.InspEquipId,
                        principalTable: "InspEquipModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProdInspectionRecords_ProdCtrlNoModels_ProdCtrlNoId",
                        column: x => x.ProdCtrlNoId,
                        principalTable: "ProdCtrlNoModels",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspEquipRecordModels_FullInspectionModelId",
                table: "InspEquipRecordModels",
                column: "FullInspectionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_InspEquipRecordModels_InspEquipId",
                table: "InspEquipRecordModels",
                column: "InspEquipId");

            migrationBuilder.CreateIndex(
                name: "IX_InspEquipRecordModels_InspSpecId",
                table: "InspEquipRecordModels",
                column: "InspSpecId");

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
                name: "IX_ProdCtrlNoModels_ProdInfoId",
                table: "ProdCtrlNoModels",
                column: "ProdInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdInspectionRecords_FullInspectionModelId",
                table: "ProdInspectionRecords",
                column: "FullInspectionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdInspectionRecords_InspEquipId",
                table: "ProdInspectionRecords",
                column: "InspEquipId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdInspectionRecords_ProdCtrlNoId",
                table: "ProdInspectionRecords",
                column: "ProdCtrlNoId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecModels_InspEquipId",
                table: "SpecModels",
                column: "InspEquipId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecModels_ProdInfoId",
                table: "SpecModels",
                column: "ProdInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderModels_ProdInfoId",
                table: "WorkOrderModels",
                column: "ProdInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderModels_UserIdentityId",
                table: "WorkOrderModels",
                column: "UserIdentityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CaseLotModels");

            migrationBuilder.DropTable(
                name: "InspEquipRecordModels");

            migrationBuilder.DropTable(
                name: "OutgoingInspModels");

            migrationBuilder.DropTable(
                name: "ProcessStatusModels");

            migrationBuilder.DropTable(
                name: "ProdInspectionRecords");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "SpecModels");

            migrationBuilder.DropTable(
                name: "FullInspectionRecords");

            migrationBuilder.DropTable(
                name: "ProdCtrlNoModels");

            migrationBuilder.DropTable(
                name: "InspEquipModels");

            migrationBuilder.DropTable(
                name: "WorkOrderModels");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProdInfoModels");
        }
    }
}
