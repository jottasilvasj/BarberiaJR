using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbearia.Migrations
{
    /// <inheritdoc />
    public partial class DuracaoServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DuracaoMinutos",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuracaoMinutos",
                table: "Servicos");
        }
    }
}
