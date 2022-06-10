using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FilmesAPI.Migrations
{
    public partial class Relacionamentonnfilmescinemasfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sessoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CinemaFK = table.Column<int>(type: "int", nullable: false),
                    FilmeFk = table.Column<int>(type: "int", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessoes_Cinemas_CinemaFK",
                        column: x => x.CinemaFK,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessoes_Filmes_FilmeFk",
                        column: x => x.FilmeFk,
                        principalTable: "Filmes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_CinemaFK",
                table: "Sessoes",
                column: "CinemaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_FilmeFk",
                table: "Sessoes",
                column: "FilmeFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessoes");
        }
    }
}
