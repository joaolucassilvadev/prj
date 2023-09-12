using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prj.Migrations
{
    /// <inheritdoc />
    public partial class crudsimulador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimo");

            migrationBuilder.CreateTable(
                name: "Simulador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    setor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    leitos = table.Column<int>(type: "int", nullable: false),
                    ala = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salas = table.Column<int>(type: "int", nullable: false),
                    dimensionamento = table.Column<int>(type: "int", nullable: false),
                    carga = table.Column<int>(type: "int", nullable: false),
                    escala = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    equipemin = table.Column<int>(type: "int", nullable: false),
                    rhminimo = table.Column<int>(type: "int", nullable: false),
                    rhminimoturno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulador", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Simulador");

            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.Id);
                });
        }
    }
}
