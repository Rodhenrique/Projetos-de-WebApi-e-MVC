using Microsoft.EntityFrameworkCore.Migrations;

namespace Redeservice_WebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    cep = table.Column<string>(nullable: true),
                    localidade = table.Column<string>(nullable: true),
                    bairro = table.Column<string>(nullable: true),
                    logradouro = table.Column<string>(nullable: true),
                    casa_num = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
