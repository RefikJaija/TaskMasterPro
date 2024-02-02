using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcAuth.Data.Migrations
{
    /// <inheritdoc />
    public partial class TeamNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Teams_TeamId",
                table: "Assignment");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Assignment",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Teams_TeamId",
                table: "Assignment",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Teams_TeamId",
                table: "Assignment");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Assignment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Teams_TeamId",
                table: "Assignment",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
