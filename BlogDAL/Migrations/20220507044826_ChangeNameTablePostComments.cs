using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogDAL.Migrations
{
    public partial class ChangeNameTablePostComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_PostComments_parentId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Posts_postId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Users_userId",
                table: "PostComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostComments",
                table: "PostComments");

            migrationBuilder.RenameTable(
                name: "PostComments",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_PostComments_userId",
                table: "Comments",
                newName: "IX_Comments_userId");

            migrationBuilder.RenameIndex(
                name: "IX_PostComments_postId",
                table: "Comments",
                newName: "IX_Comments_postId");

            migrationBuilder.RenameIndex(
                name: "IX_PostComments_parentId",
                table: "Comments",
                newName: "IX_Comments_parentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_parentId",
                table: "Comments",
                column: "parentId",
                principalTable: "Comments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_postId",
                table: "Comments",
                column: "postId",
                principalTable: "Posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_userId",
                table: "Comments",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_parentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_postId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_userId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "PostComments");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_userId",
                table: "PostComments",
                newName: "IX_PostComments_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_postId",
                table: "PostComments",
                newName: "IX_PostComments_postId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_parentId",
                table: "PostComments",
                newName: "IX_PostComments_parentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostComments",
                table: "PostComments",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_PostComments_parentId",
                table: "PostComments",
                column: "parentId",
                principalTable: "PostComments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Posts_postId",
                table: "PostComments",
                column: "postId",
                principalTable: "Posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Users_userId",
                table: "PostComments",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
