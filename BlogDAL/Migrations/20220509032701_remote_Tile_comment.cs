using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogDAL.Migrations
{
    public partial class remote_Tile_comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "title",
                table: "Comments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registerAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 9, 10, 27, 0, 772, DateTimeKind.Local).AddTicks(821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 9, 8, 29, 33, 269, DateTimeKind.Local).AddTicks(8159));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "registerAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 9, 8, 29, 33, 269, DateTimeKind.Local).AddTicks(8159),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 9, 10, 27, 0, 772, DateTimeKind.Local).AddTicks(821));

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Comments",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
