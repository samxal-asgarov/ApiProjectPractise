using Microsoft.EntityFrameworkCore.Migrations;

namespace PostUser.Migrations
{
    public partial class hdhdhd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Posts_PostsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PostsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostsId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UsersId",
                table: "Posts",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UsersId",
                table: "Posts",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UsersId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UsersId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "PostsId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PostsId",
                table: "Users",
                column: "PostsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Posts_PostsId",
                table: "Users",
                column: "PostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
