using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mecanica.Modelos.Migrations
{
    public partial class AdicionaTabelasIniciais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SLAs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLAs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeServicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Observacoes = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeServicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfils",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoleId1 = table.Column<Guid>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    Login = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfils_Roles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PerfilId1 = table.Column<Guid>(nullable: false),
                    PerfilId = table.Column<int>(nullable: false),
                    Marca = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Especificacao = table.Column<string>(nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    Modelo = table.Column<string>(nullable: false),
                    Kilometragem = table.Column<int>(nullable: false),
                    Placa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_Perfils_PerfilId1",
                        column: x => x.PerfilId1,
                        principalTable: "Perfils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TipoDeServicoId1 = table.Column<Guid>(nullable: true),
                    TipoDeServicoId = table.Column<int>(nullable: false),
                    VeiculoId1 = table.Column<Guid>(nullable: false),
                    VeiculoId = table.Column<int>(nullable: false),
                    ValorMaoDeObra = table.Column<double>(nullable: false),
                    ValorPecas = table.Column<double>(nullable: false),
                    ValorTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_TipoDeServicos_TipoDeServicoId1",
                        column: x => x.TipoDeServicoId1,
                        principalTable: "TipoDeServicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_Veiculos_VeiculoId1",
                        column: x => x.VeiculoId1,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_TipoDeServicoId1",
                table: "Pedidos",
                column: "TipoDeServicoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_VeiculoId1",
                table: "Pedidos",
                column: "VeiculoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Perfils_RoleId1",
                table: "Perfils",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_PerfilId1",
                table: "Veiculos",
                column: "PerfilId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "SLAs");

            migrationBuilder.DropTable(
                name: "TipoDeServicos");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Perfils");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
