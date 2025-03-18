using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetekLisansApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangedLisans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LisansVerilmeTarihi",
                table: "Lisanslar",
                newName: "LisansVerilmeTarih");

            migrationBuilder.AddColumn<DateTime>(
                name: "LisansBitisTarih",
                table: "Lisanslar",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LisansBitisTarih",
                table: "Lisanslar");

            migrationBuilder.RenameColumn(
                name: "LisansVerilmeTarih",
                table: "Lisanslar",
                newName: "LisansVerilmeTarihi");
        }
    }
}
