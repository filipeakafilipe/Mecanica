using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mecanica.Modelos;
using Mecanica.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private UnidadeDeTrabalho _context;

        public PedidoController()
        {
            _context = new UnidadeDeTrabalho();
        }

        [HttpGet("{id}")]
        public ActionResult<Pedido> GetPedido(int id)
        {
            var pedido = _context.PedidoRepositorio.Get(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }


        [HttpPost]
        public ActionResult<Perfil> CriarPerfil(Pedido pedido)
        {
            _context.PedidoRepositorio.Adicionar(pedido);

            return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id }, pedido);
        }

        [HttpGet("todos")]
        public ActionResult<List<Pedido>> GetTodosPedidos()
        {
            return _context.PedidoRepositorio.GetTodos();
        }

        [HttpPut]
        public void AtualizarPedido(Pedido pedido)
        {
            _context.PedidoRepositorio.Atualizar(pedido.Id, pedido);
        }
    }
}
