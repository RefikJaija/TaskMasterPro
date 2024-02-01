using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcAuth.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserIdNotReq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_AspNetUsers_UserID",
                table: "Assignment");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Assignment",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_AspNetUsers_UserID",
                table: "Assignment",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_AspNetUsers_UserID",
                table: "Assignment");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Assignment",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_AspNetUsers_UserID",
                table: "Assignment",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
