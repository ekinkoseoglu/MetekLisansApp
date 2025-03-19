using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetekLisansApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleToKullanicilar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roller",
                table: "Menuler");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Roller",
                table: "Ekranlar");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Kullanicilar",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Kullanicilar");

            migrationBuilder.AddColumn<string>(
                name: "Roller",
                table: "Menuler",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Kullanicilar",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Roller",
                table: "Ekranlar",
                type: "TEXT",
                nullable: true);
        }
    }
}
