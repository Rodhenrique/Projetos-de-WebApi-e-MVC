using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi_Canil.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Raca",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    titulo = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raca", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Caes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    apelido = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    idRaca = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caes", x => x.id);
                    table.ForeignKey(
                        name: "FK__Caes__idRaca__286302EC",
                        column: x => x.idRaca,
                        principalTable: "Raca",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Caes_Dono",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idCao = table.Column<int>(nullable: true),
                    idDono = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caes_Dono", x => x.id);
                    table.ForeignKey(
                        name: "FK__Caes_Dono__idCao__2B3F6F97",
                        column: x => x.idCao,
                        principalTable: "Caes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Caes_Dono__idDon__2C3393D0",
                        column: x => x.idDono,
                        principalTable: "Donos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caes_idRaca",
                table: "Caes",
                column: "idRaca");

            migrationBuilder.CreateIndex(
                name: "IX_Caes_Dono_idCao",
                table: "Caes_Dono",
                column: "idCao");

            migrationBuilder.CreateIndex(
                name: "IX_Caes_Dono_idDono",
                table: "Caes_Dono",
                column: "idDono");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caes_Dono");

            migrationBuilder.DropTable(
                name: "Caes");

            migrationBuilder.DropTable(
                name: "Donos");

            migrationBuilder.DropTable(
                name: "Raca");
        }
    }
}
