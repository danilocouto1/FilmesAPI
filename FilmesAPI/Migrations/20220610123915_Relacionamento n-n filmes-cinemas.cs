using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FilmesAPI.Migrations
{
    public partial class Relacionamentonnfilmescinemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sessaoes",
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
                    table.PrimaryKey("PK_Sessaoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessaoes_Cinemas_CinemaFK",
                        column: x => x.CinemaFK,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessaoes_Filmes_FilmeFk",
                        column: x => x.FilmeFk,
                        principalTable: "Filmes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessaoes_CinemaFK",
                table: "Sessaoes",
                column: "CinemaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Sessaoes_FilmeFk",
                table: "Sessaoes",
                column: "FilmeFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessaoes");
        }
    }
}
