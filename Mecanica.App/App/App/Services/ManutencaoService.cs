using App.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Services
{
    public static class ManutencaoService
    {
        public static List<Manutencao> GetManutencoesCliente(Perfil usuario)
        {
            try
            {
                var pedidos = PedidoService.GetPedidosDoCliente(usuario.Id).Result;

                var veiculosDoCliente = VeiculoService.GetVeiculosCliente(usuario.Id).Result;

                var tiposDeServico = TipoDeServicoService.GetTipoDeServicos().Result;

                var manutencoes = new List<Manutencao>();

                foreach (var pedido in pedidos)
                {
                    var manutencao = new Manutencao();

                    foreach (var veiculo in veiculosDoCliente)
                    {
                        if (veiculo.Id == pedido.VeiculoId)
                        {
                            manutencao.Nome = veiculo.Nome;
                            manutencao.Placa = veiculo.Placa;

                            foreach (var tipo in tiposDeServico)
                            {
                                if (tipo.Id == pedido.TipoDeServicoId)
                                {
                                    manutencao.TipoDeServico = tipo.Nome;

                                    manutencao.Status = pedido.SLA;

                                    manutencao.Valor = pedido.ValorMaoDeObra + pedido.ValorPecas;

                                    manutencoes.Add(manutencao);

                                    break;
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(manutencao.Placa))
                        {
                            break;
                        }
                    }
                }

                return manutencoes.OrderBy(m => m.Placa).ThenBy(m => m.Valor).ToList();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
