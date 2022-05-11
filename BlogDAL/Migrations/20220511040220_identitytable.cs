using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogDAL.Migrations
{
    public partial class identitytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30e61782-f64d-4f23-9430-d9f10fe725ad", "1de20c1a-3735-421e-9b5f-4cd6aefba1bc", "member", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "951e8cd3-7dea-4f04-a0e5-bfdd7eedb602", "ecfa2d57-1759-4195-85dd-46857d342724", "moderator", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "30e61782-f64d-4f23-9430-d9f10fe725ad");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "951e8cd3-7dea-4f04-a0e5-bfdd7eedb602");
        }
    }
}
