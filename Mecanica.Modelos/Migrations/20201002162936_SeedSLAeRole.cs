using Microsoft.EntityFrameworkCore.Migrations;

namespace Mecanica.Modelos.Migrations
{
    public partial class SeedSLAeRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Mecânico" },
                    { 3, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "SLAs",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Criado" },
                    { 2, "Em trabalho" },
                    { 3, "Finalizado" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SLAs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SLAs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SLAs",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
