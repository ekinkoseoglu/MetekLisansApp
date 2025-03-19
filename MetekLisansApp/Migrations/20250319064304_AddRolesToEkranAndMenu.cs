using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetekLisansApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToEkranAndMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Roller",
                table: "Menuler",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Roller",
                table: "Ekranlar",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roller",
                table: "Menuler");

            migrationBuilder.DropColumn(
                name: "Roller",
                table: "Ekranlar");
        }
    }
}
