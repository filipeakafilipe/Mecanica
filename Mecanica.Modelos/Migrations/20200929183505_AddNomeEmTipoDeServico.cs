using Microsoft.EntityFrameworkCore.Migrations;

namespace Mecanica.Modelos.Migrations
{
    public partial class AddNomeEmTipoDeServico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "TipoDeServicos",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "TipoDeServicos");
        }
    }
}
