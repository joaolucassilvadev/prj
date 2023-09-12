using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prj.Migrations
{
    /// <inheritdoc />
    public partial class simulador2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "valor",
                table: "Simulador",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "valor",
                table: "Simulador");
        }
    }
}
