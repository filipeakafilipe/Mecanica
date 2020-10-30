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
        private readonly IPedidoRepository<Pedido> _context;

        public PedidoController(IPedidoRepository<Pedido> context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Pedido> GetPedido(int id)
        {
            var pedido = _context.Get(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }


        [HttpPost]
        public ActionResult<Perfil> CriarPerfil(Pedido pedido)
        {
            try
            {
                _context.Adicionar(pedido);

                return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id }, pedido);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("todos")]
        public ActionResult<List<Pedido>> GetTodosPedidos()
        {
            return _context.GetTodos();
        }

        [HttpPut]
        public ActionResult AtualizarPedido(Pedido pedido)
        {
            try
            {
                _context.Atualizar(pedido.Id, pedido);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("cliente/{idCliente}")]
        public ActionResult<List<Pedido>> GetPedidosDoCliente(int idCliente)
        {
            return _context.GetPedidosDoCliente(idCliente);
        }

        [HttpGet("atuais")]
        public ActionResult<List<Pedido>> GetPedidosNaoFinalizados()
        {
            return _context.GetPedidosNaoFinalizados();
        }
    }
}
