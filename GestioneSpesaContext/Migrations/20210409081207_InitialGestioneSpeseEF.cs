using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestioneSpesaContext.Migrations
{
    public partial class InitialGestioneSpeseEF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaNome = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Spese",
                columns: table => new
                {
                    SpeseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    Descrizione = table.Column<string>(maxLength: 500, nullable: true),
                    Utente = table.Column<string>(maxLength: 100, nullable: true),
                    Importo = table.Column<decimal>(nullable: false),
                    Approvato = table.Column<bool>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spese", x => x.SpeseId);
                    table.ForeignKey(
                        name: "FK_Spese_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spese_CategoriaId",
                table: "Spese",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spese");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
