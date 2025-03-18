using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetekLisansApp.Migrations
{
    /// <inheritdoc />
    public partial class LisansModelUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SeciliDegerler",
                table: "Lisanslar",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeciliDegerler",
                table: "Lisanslar");
        }
    }
}
