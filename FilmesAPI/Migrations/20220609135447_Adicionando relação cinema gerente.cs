using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FilmesAPI.Migrations
{
    public partial class Adicionandorelaçãocinemagerente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GerenteFK",
                table: "Cinemas",
                type: "int",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.CreateTable(
                name: "Gerentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerentes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_GerenteFK",
                table: "Cinemas",
                column: "GerenteFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerentes_GerenteFK",
                table: "Cinemas",
                column: "GerenteFK",
                principalTable: "Gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Gerentes_GerenteFK",
                table: "Cinemas");

            migrationBuilder.DropTable(
                name: "Gerentes");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_GerenteFK",
                table: "Cinemas");
        }
    }
}
