using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prj.Migrations
{
    /// <inheritdoc />
    public partial class emprestimobanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    setor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ch = table.Column<int>(type: "int", nullable: false),
                    rhreal = table.Column<int>(type: "int", nullable: false),
                    rhideal = table.Column<int>(type: "int", nullable: false),
                    comporativo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimo");
        }
    }
}
