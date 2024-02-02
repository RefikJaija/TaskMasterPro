using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcAuth.Data.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyAssgTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentTeams");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Assignment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_TeamId",
                table: "Assignment",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Teams_TeamId",
                table: "Assignment",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Teams_TeamId",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_TeamId",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Assignment");

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
    }
}
