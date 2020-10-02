using Microsoft.EntityFrameworkCore.Migrations;

namespace Mecanica.Modelos.Migrations
{
    public partial class AddSLAPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SLA",
                table: "Pedidos",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SLA",
                table: "Pedidos");
        }
    }
}
