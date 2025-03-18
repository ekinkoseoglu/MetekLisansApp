using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetekLisansApp.Migrations
{
    /// <inheritdoc />
    public partial class FixProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MenuAd",
                table: "Menuler",
                newName: "Ad");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Menuler",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LisansId",
                table: "Lisanslar",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "KullaniciId",
                table: "Kullanicilar",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FirmaKod",
                table: "Firmalar",
                newName: "Kod");

            migrationBuilder.RenameColumn(
                name: "FirmaAd",
                table: "Firmalar",
                newName: "Ad");

            migrationBuilder.RenameColumn(
                name: "FirmaId",
                table: "Firmalar",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EkranAd",
                table: "Ekranlar",
                newName: "Ad");

            migrationBuilder.RenameColumn(
                name: "EkranId",
                table: "Ekranlar",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Menuler",
                newName: "MenuAd");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Menuler",
                newName: "MenuId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lisanslar",
                newName: "LisansId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Kullanicilar",
                newName: "KullaniciId");

            migrationBuilder.RenameColumn(
                name: "Kod",
                table: "Firmalar",
                newName: "FirmaKod");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Firmalar",
                newName: "FirmaAd");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Firmalar",
                newName: "FirmaId");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Ekranlar",
                newName: "EkranAd");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ekranlar",
                newName: "EkranId");
        }
    }
}
