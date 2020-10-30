using Mecanica.Modelos;
using Mecanica.Modelos.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mecanica.Repositorios
{
    public class PedidoRepositorio : BaseRepositorio, IPedidoRepository<Pedido>
    {
        public PedidoRepositorio() : base()
        {

        }

        public Pedido Get(int id)
        {
            return db.Pedidos.Where(v => v.Id == id).FirstOrDefault();
        }

        public void Adicionar(Pedido pedido)
        {
            db.Pedidos.Add(pedido);

            db.SaveChanges();
        }

        public void Remover(int id)
        {
            var pedido = db.Pedidos.Where(v => v.Id == id).FirstOrDefault();

            db.Pedidos.Remove(pedido);

            db.SaveChanges();
        }

        public void Atualizar(int id, Pedido novoPedido)
        {
            var pedido = Get(id);

            if (pedido != null)
            {
                pedido.TipoDeServicoId = novoPedido.TipoDeServicoId;
                pedido.ValorMaoDeObra = novoPedido.ValorMaoDeObra;
                pedido.ValorPecas = novoPedido.ValorPecas;
                pedido.SLA = novoPedido.SLA;

                db.Entry(pedido).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public List<Pedido> GetTodos()
        {
            try
            {
                var tiposDeServico = db.TipoDeServicos.ToList();

                var veiculos = db.Veiculos.ToList();

                var pedidos = db.Pedidos.ToList();

                pedidos.ForEach(p =>
                {
                    p.TipoDeServico = tiposDeServico.Where(t => t.Id == p.TipoDeServicoId).FirstOrDefault();
                    p.Veiculo = veiculos.Where(v => v.Id == p.VeiculoId).FirstOrDefault();
                });

                return pedidos;
            }
            catch
            {
                return null;
            }
        }

        public List<Pedido> GetPedidosDoCliente(int idCliente)
        {
            try
            {
                var veiculos = new VeiculoRepositorio().GetVeiculoCliente(idCliente);

                var pedidos = db.Pedidos.ToList();

                return pedidos.Where(p => veiculos.Any(v => v.Id == p.VeiculoId)).OrderBy(p => p.SLA).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Pedido> GetPedidosNaoFinalizados()
        {
            try
            {
                var tiposDeServico = db.TipoDeServicos.ToList();

                var veiculos = db.Veiculos.ToList();

                var pedidos = db.Pedidos.Where(p => p.SLA != Enum.GetName(typeof(SLAEnum), 3)).OrderBy(p => p.SLA).ToList();

                pedidos.ForEach(p =>
                {
                    p.TipoDeServico = tiposDeServico.Where(t => t.Id == p.TipoDeServicoId).FirstOrDefault();
                    p.Veiculo = veiculos.Where(v => v.Id == p.VeiculoId).FirstOrDefault();
                });

                return pedidos;
            }
            catch
            {
                return null;
            }
        }
    }
}
