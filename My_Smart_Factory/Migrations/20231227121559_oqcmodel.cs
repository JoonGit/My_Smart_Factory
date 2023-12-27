using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Smart_Factory.Migrations
{
    /// <inheritdoc />
    public partial class oqcmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OqcModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Controlnumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProcessName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InspectionTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InspectionResult = table.Column<int>(type: "int", nullable: false),
                    Inspector = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Confirmor = table.Column<string>(type: "longtext", nullable: false)
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
                    EtcInfo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OqcModels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OqcModels");
        }
    }
}
