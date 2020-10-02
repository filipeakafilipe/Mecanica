using Mecanica.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mecanica.Repositorios
{
    public class PedidoRepositorio : BaseRepositorio
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

            pedido.TipoDeServicoId = novoPedido.TipoDeServicoId;
            pedido.ValorMaoDeObra = novoPedido.ValorMaoDeObra;
            pedido.ValorPecas = novoPedido.ValorPecas;
            pedido.SLA = novoPedido.SLA;

            db.Entry(pedido).State = EntityState.Modified;

            db.SaveChanges();
        }

        public List<Pedido> GetTodos()
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
    }
}
