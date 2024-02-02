using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcAuth.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAssignmentTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Teams_TeamID",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_TeamID",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Assignment");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Assignment",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AssignmentTeams",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentTeams", x => new { x.AssignmentID, x.TeamId });
                    table.ForeignKey(
                        name: "FK_AssignmentTeams_Assignment_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignment",
                        principalColumn: "AssignmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentTeams_TeamId",
                table: "AssignmentTeams",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentTeams");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Assignment");

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Assignment",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_TeamID",
                table: "Assignment",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Teams_TeamID",
                table: "Assignment",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID");
        }
    }
}
