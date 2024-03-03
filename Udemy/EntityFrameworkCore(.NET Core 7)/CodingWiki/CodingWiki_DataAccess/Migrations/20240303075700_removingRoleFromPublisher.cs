using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removingRoleFromPublisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publishers_Role_Role_Id",
                table: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_Publishers_Role_Id",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Role_Id",
                table: "Publishers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role_Id",
                table: "Publishers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Publisher_Id",
                keyValue: 1,
                column: "Role_Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Publisher_Id",
                keyValue: 2,
                column: "Role_Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Publisher_Id",
                keyValue: 4,
                column: "Role_Id",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_Role_Id",
                table: "Publishers",
                column: "Role_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publishers_Role_Role_Id",
                table: "Publishers",
                column: "Role_Id",
                principalTable: "Role",
                principalColumn: "Role_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
