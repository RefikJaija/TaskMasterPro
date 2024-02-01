using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcAuth.Data.Migrations
{
    /// <inheritdoc />
    public partial class IsPrvDel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Assignment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Assignment",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
