using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMemberships_AspNetUsers_AppuserId",
                table: "UserMemberships");

            migrationBuilder.DropIndex(
                name: "IX_UserMemberships_AppuserId",
                table: "UserMemberships");

            migrationBuilder.DropColumn(
                name: "AppuserId",
                table: "UserMemberships");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppuserId",
                table: "UserMemberships",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMemberships_AppuserId",
                table: "UserMemberships",
                column: "AppuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMemberships_AspNetUsers_AppuserId",
                table: "UserMemberships",
                column: "AppuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
