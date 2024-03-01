using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Role_Id", "Name" },
                values: new object[,]
                {
                    { 1, "Normal" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Publisher_Id", "Location", "Name", "Role_Id" },
                values: new object[,]
                {
                    { 1, "efeoeffe", "Stoqn", 1 },
                    { 2, "wdwwd", "Mariqn", 1 },
                    { 4, "vitoshka", "Andrei", 1 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Book_Id", "ISBN", "Price", "Publisher_Id", "Title" },
                values: new object[,]
                {
                    { 2, "123B12", 10.99m, 2, "spider" },
                    { 4, "2323", 10.99m, 1, "panda" },
                    { 5, "23", 16.99m, 1, "wow" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Book_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Book_Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Book_Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Publisher_Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Role_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Publisher_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Publisher_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Role_Id",
                keyValue: 1);
        }
    }
}
