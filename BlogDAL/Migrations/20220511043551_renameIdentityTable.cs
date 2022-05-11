using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogDAL.Migrations
{
    public partial class renameIdentityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("04acc448-8013-490e-a9d3-bf84a6f5b890"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2a051e47-529e-47ec-b1e9-97ba4f9012be"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4531054b-da0f-46e3-9e0a-0be73e7cc414"), new Guid("e4216777-dfa9-4997-9da0-4c17f90db79c") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4531054b-da0f-46e3-9e0a-0be73e7cc414"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e4216777-dfa9-4997-9da0-4c17f90db79c"));

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AppUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AppUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AppUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AppUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AppRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AppUserRoles",
                newName: "IX_AppUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AppUserClaims",
                newName: "IX_AppUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AppRoleClaims",
                newName: "IX_AppRoleClaims_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AppUserTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AppUserTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AppUserLogins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AppUserLogins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserTokens",
                table: "AppUserTokens",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserRoles",
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserLogins",
                table: "AppUserLogins",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserClaims",
                table: "AppUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppRoleClaims",
                table: "AppRoleClaims",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("033f0c31-6ad7-4f4f-8516-0f9b77778564"), "b8b46e3d-b8fd-4d10-9ff8-5c580834b9b0", "member", null },
                    { new Guid("21268a66-1311-4d2d-98ae-ae130bfbb667"), "d7ec02f6-9f5c-401b-8860-3e3ce37dd4f3", "moderator", null },
                    { new Guid("cd9eb2d2-78ee-4390-b1bc-97b91347ffcb"), "6969eb2a-07f2-4474-aa2e-e57534422528", "admin", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "intro", "lastLogin", "profile", "registerAt" },
                values: new object[] { new Guid("f0149822-569b-4324-9b44-ebec8d524027"), 0, "db753f56-f6af-4c56-bd6c-747d14221e65", "tungnh230802@gmail.com", true, false, null, "tungnh230802@gmail.com", "admin", "AQAAAAEAACcQAAAAEMHG0IjpBsntRBHDqF5NW7eEODr+lgshBfkl31daaMU5mkocjYtmnUEm9bC9BpQmRg==", null, false, "", false, "admin", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("cd9eb2d2-78ee-4390-b1bc-97b91347ffcb"), new Guid("f0149822-569b-4324-9b44-ebec8d524027") });

            migrationBuilder.AddForeignKey(
                name: "FK_AppRoleClaims_AspNetRoles_RoleId",
                table: "AppRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserClaims_AspNetUsers_UserId",
                table: "AppUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserLogins_AspNetUsers_UserId",
                table: "AppUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserRoles_AspNetRoles_RoleId",
                table: "AppUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserRoles_AspNetUsers_UserId",
                table: "AppUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserTokens_AspNetUsers_UserId",
                table: "AppUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRoleClaims_AspNetRoles_RoleId",
                table: "AppRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserClaims_AspNetUsers_UserId",
                table: "AppUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserLogins_AspNetUsers_UserId",
                table: "AppUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserRoles_AspNetRoles_RoleId",
                table: "AppUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserRoles_AspNetUsers_UserId",
                table: "AppUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserTokens_AspNetUsers_UserId",
                table: "AppUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserTokens",
                table: "AppUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserRoles",
                table: "AppUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserLogins",
                table: "AppUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserClaims",
                table: "AppUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppRoleClaims",
                table: "AppRoleClaims");

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cd9eb2d2-78ee-4390-b1bc-97b91347ffcb"), new Guid("f0149822-569b-4324-9b44-ebec8d524027") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("033f0c31-6ad7-4f4f-8516-0f9b77778564"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("21268a66-1311-4d2d-98ae-ae130bfbb667"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cd9eb2d2-78ee-4390-b1bc-97b91347ffcb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f0149822-569b-4324-9b44-ebec8d524027"));

            migrationBuilder.RenameTable(
                name: "AppUserTokens",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AppUserRoles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AppUserLogins",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AppUserClaims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AppRoleClaims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2a051e47-529e-47ec-b1e9-97ba4f9012be"), "a4131996-35c5-427d-9973-f28e074fa86f", "member", null },
                    { new Guid("04acc448-8013-490e-a9d3-bf84a6f5b890"), "3c1eb047-86ed-46e8-8b43-7cd2d9c08b97", "moderator", null },
                    { new Guid("4531054b-da0f-46e3-9e0a-0be73e7cc414"), "82e25330-0dcb-40f1-a9d1-737165a27593", "admin", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "intro", "lastLogin", "profile", "registerAt" },
                values: new object[] { new Guid("e4216777-dfa9-4997-9da0-4c17f90db79c"), 0, "d9369855-518d-4c2e-81cf-a986eff32b53", "tungnh230802@gmail.com", true, false, null, "tungnh230802@gmail.com", "admin", "AQAAAAEAACcQAAAAED4w1KuayIPUo5jEAzemYZ5hu0zKWOq5J6WXeR/wCmduH0oOFYqtndQdhZ1IZN5n6A==", null, false, "", false, "admin", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("4531054b-da0f-46e3-9e0a-0be73e7cc414"), new Guid("e4216777-dfa9-4997-9da0-4c17f90db79c") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
