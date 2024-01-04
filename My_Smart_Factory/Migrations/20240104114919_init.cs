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
                    ProdWeight = table.Column<decimal>(type: "decimal(65,30)", nullable: true)
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
                name: "InspSpecModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InspSpecName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProdInfoId = table.Column<int>(type: "int", nullable: true),
                    InspEquipId = table.Column<int>(type: "int", nullable: true),
                    ETR = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspSpecModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspSpecModels_InspEquipModels_InspEquipId",
                        column: x => x.InspEquipId,
                        principalTable: "InspEquipModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspSpecModels_ProdInfoModels_ProdInfoId",
                        column: x => x.ProdInfoId,
                        principalTable: "ProdInfoModels",
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
                    ProdCtrlNo = table.Column<string>(type: "longtext", nullable: true)
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
                name: "WorkOrderModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WorkOrderNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkOrderDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ProdInfoId = table.Column<int>(type: "int", nullable: true),
                    WorkOrderIssuerId = table.Column<string>(type: "varchar(255)", nullable: true)
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
                        name: "FK_WorkOrderModels_AspNetUsers_WorkOrderIssuerId",
                        column: x => x.WorkOrderIssuerId,
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

            migrationBuilder.CreateTable(
                name: "InspEquipSettingRecordModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InspEquipId = table.Column<int>(type: "int", nullable: true),
                    InspSpecId = table.Column<int>(type: "int", nullable: true),
                    InspectionDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IES = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Accuracy = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    FullInspRecordModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspEquipSettingRecordModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspEquipSettingRecordModels_FullInspRecordModels_FullInspRe~",
                        column: x => x.FullInspRecordModelId,
                        principalTable: "FullInspRecordModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspEquipSettingRecordModels_InspEquipModels_InspEquipId",
                        column: x => x.InspEquipId,
                        principalTable: "InspEquipModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspEquipSettingRecordModels_InspSpecModels_InspSpecId",
                        column: x => x.InspSpecId,
                        principalTable: "InspSpecModels",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InspProdRecordModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InspSpecId = table.Column<int>(type: "int", nullable: true),
                    ProdCtrlNoId = table.Column<int>(type: "int", nullable: true),
                    InspectionDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    MeasuredValue = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Accuracy = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    IsPassed = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    FullInspRecordModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspProdRecordModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspProdRecordModels_FullInspRecordModels_FullInspRecordMode~",
                        column: x => x.FullInspRecordModelId,
                        principalTable: "FullInspRecordModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspProdRecordModels_InspSpecModels_InspSpecId",
                        column: x => x.InspSpecId,
                        principalTable: "InspSpecModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspProdRecordModels_ProdCtrlNoModels_ProdCtrlNoId",
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
                name: "IX_InspEquipSettingRecordModels_FullInspRecordModelId",
                table: "InspEquipSettingRecordModels",
                column: "FullInspRecordModelId");

            migrationBuilder.CreateIndex(
                name: "IX_InspEquipSettingRecordModels_InspEquipId",
                table: "InspEquipSettingRecordModels",
                column: "InspEquipId");

            migrationBuilder.CreateIndex(
                name: "IX_InspEquipSettingRecordModels_InspSpecId",
                table: "InspEquipSettingRecordModels",
                column: "InspSpecId");

            migrationBuilder.CreateIndex(
                name: "IX_InspProdRecordModels_FullInspRecordModelId",
                table: "InspProdRecordModels",
                column: "FullInspRecordModelId");

            migrationBuilder.CreateIndex(
                name: "IX_InspProdRecordModels_InspSpecId",
                table: "InspProdRecordModels",
                column: "InspSpecId");

            migrationBuilder.CreateIndex(
                name: "IX_InspProdRecordModels_ProdCtrlNoId",
                table: "InspProdRecordModels",
                column: "ProdCtrlNoId");

            migrationBuilder.CreateIndex(
                name: "IX_InspSpecModels_InspEquipId",
                table: "InspSpecModels",
                column: "InspEquipId");

            migrationBuilder.CreateIndex(
                name: "IX_InspSpecModels_ProdInfoId",
                table: "InspSpecModels",
                column: "ProdInfoId");

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
                name: "IX_WorkOrderModels_ProdInfoId",
                table: "WorkOrderModels",
                column: "ProdInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderModels_WorkOrderIssuerId",
                table: "WorkOrderModels",
                column: "WorkOrderIssuerId");
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
                name: "InspEquipSettingRecordModels");

            migrationBuilder.DropTable(
                name: "InspProdRecordModels");

            migrationBuilder.DropTable(
                name: "OutgoingInspModels");

            migrationBuilder.DropTable(
                name: "ProcessStatusModels");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FullInspRecordModels");

            migrationBuilder.DropTable(
                name: "InspSpecModels");

            migrationBuilder.DropTable(
                name: "ProdCtrlNoModels");

            migrationBuilder.DropTable(
                name: "WorkOrderModels");

            migrationBuilder.DropTable(
                name: "InspEquipModels");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProdInfoModels");
        }
    }
}
