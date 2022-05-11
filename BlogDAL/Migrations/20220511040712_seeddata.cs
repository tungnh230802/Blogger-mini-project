using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogDAL.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "30e61782-f64d-4f23-9430-d9f10fe725ad");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "951e8cd3-7dea-4f04-a0e5-bfdd7eedb602");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5dc57faf-2f6e-460a-b7df-1f9062a3326d", "b873e7c0-9147-488b-8d72-3afa2dea5fbe", "member", null },
                    { "43e8dd12-0cc0-4100-9402-90a53d3e5bb2", "e86f23ac-8333-4459-a448-d66863c6ccdd", "moderator", null },
                    { "8d04dce2-969a-435d-bba4-df3f325983dc", "92c58323-d7c7-4dd4-ae97-f80ddfe9e949", "admin", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "intro", "lastLogin", "profile", "registerAt" },
                values: new object[] { "69bd714f-9576-45ba-b5b7-f00649be00de", 0, "b6a2e5ae-e0c0-483c-a90d-64ed7bd3c636", "tungnh230802@gmail.com", true, false, null, "tungnh230802@gmail.com", "admin", "AQAAAAEAACcQAAAAEP/wG7k5tthiWHP6bqYjelBWVl3eVtgrG2I02w3B1b75OXbosCim+zsq2II9b1trfg==", null, false, "", false, "admin", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8d04dce2-969a-435d-bba4-df3f325983dc", "69bd714f-9576-45ba-b5b7-f00649be00de" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "43e8dd12-0cc0-4100-9402-90a53d3e5bb2");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5dc57faf-2f6e-460a-b7df-1f9062a3326d");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d04dce2-969a-435d-bba4-df3f325983dc", "69bd714f-9576-45ba-b5b7-f00649be00de" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8d04dce2-969a-435d-bba4-df3f325983dc");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "69bd714f-9576-45ba-b5b7-f00649be00de");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30e61782-f64d-4f23-9430-d9f10fe725ad", "1de20c1a-3735-421e-9b5f-4cd6aefba1bc", "member", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "951e8cd3-7dea-4f04-a0e5-bfdd7eedb602", "ecfa2d57-1759-4195-85dd-46857d342724", "moderator", null });
        }
    }
}
