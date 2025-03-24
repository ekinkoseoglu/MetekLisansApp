using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetekLisansApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTablesfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BakimAnlasmasi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakimAnlasmasi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BakimPaketi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakimPaketi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LisansSure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LisansSure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sahip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sahip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjeDurumu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirmaId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatuId = table.Column<int>(type: "INTEGER", nullable: false),
                    MevcutLisans = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LisansAtansinmi = table.Column<bool>(type: "INTEGER", nullable: false),
                    LisansSureId = table.Column<int>(type: "INTEGER", nullable: false),
                    AnlasmaId = table.Column<int>(type: "INTEGER", nullable: false),
                    BakimPaketId = table.Column<int>(type: "INTEGER", nullable: false),
                    BakimSozlesmeBitisTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Notlar = table.Column<string>(type: "TEXT", nullable: false),
                    SahipId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjeDurumu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjeDurumu_BakimAnlasmasi_AnlasmaId",
                        column: x => x.AnlasmaId,
                        principalTable: "BakimAnlasmasi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjeDurumu_BakimPaketi_BakimPaketId",
                        column: x => x.BakimPaketId,
                        principalTable: "BakimPaketi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjeDurumu_Firmalar_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firmalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjeDurumu_LisansSure_LisansSureId",
                        column: x => x.LisansSureId,
                        principalTable: "LisansSure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjeDurumu_Sahip_SahipId",
                        column: x => x.SahipId,
                        principalTable: "Sahip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjeDurumu_Statu_StatuId",
                        column: x => x.StatuId,
                        principalTable: "Statu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjeDurumu_AnlasmaId",
                table: "ProjeDurumu",
                column: "AnlasmaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeDurumu_BakimPaketId",
                table: "ProjeDurumu",
                column: "BakimPaketId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeDurumu_FirmaId",
                table: "ProjeDurumu",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeDurumu_LisansSureId",
                table: "ProjeDurumu",
                column: "LisansSureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeDurumu_SahipId",
                table: "ProjeDurumu",
                column: "SahipId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeDurumu_StatuId",
                table: "ProjeDurumu",
                column: "StatuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjeDurumu");

            migrationBuilder.DropTable(
                name: "BakimAnlasmasi");

            migrationBuilder.DropTable(
                name: "BakimPaketi");

            migrationBuilder.DropTable(
                name: "LisansSure");

            migrationBuilder.DropTable(
                name: "Sahip");

            migrationBuilder.DropTable(
                name: "Statu");
        }
    }
}
