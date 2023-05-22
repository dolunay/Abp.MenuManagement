using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperAbp.MenuManagement.Migrations
{
    /// <inheritdoc />
    public partial class MenuAddKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "SuperAbpMenu",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "SuperAbpMenu");
        }
    }
}
