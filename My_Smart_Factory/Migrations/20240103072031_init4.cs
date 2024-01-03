using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Smart_Factory.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderModels_AspNetUsers_UserIdentityId",
                table: "WorkOrderModels");

            migrationBuilder.RenameColumn(
                name: "UserIdentityId",
                table: "WorkOrderModels",
                newName: "WorkOrderIssuerId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrderModels_UserIdentityId",
                table: "WorkOrderModels",
                newName: "IX_WorkOrderModels_WorkOrderIssuerId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderModels_AspNetUsers_WorkOrderIssuerId",
                table: "WorkOrderModels",
                column: "WorkOrderIssuerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderModels_AspNetUsers_WorkOrderIssuerId",
                table: "WorkOrderModels");

            migrationBuilder.RenameColumn(
                name: "WorkOrderIssuerId",
                table: "WorkOrderModels",
                newName: "UserIdentityId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrderModels_WorkOrderIssuerId",
                table: "WorkOrderModels",
                newName: "IX_WorkOrderModels_UserIdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderModels_AspNetUsers_UserIdentityId",
                table: "WorkOrderModels",
                column: "UserIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
