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
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoRepository<Veiculo> _context;

        public VeiculoController(IVeiculoRepository<Veiculo> context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Veiculo> GetVeiculo(int id)
        {
            var veiculo = _context.Get(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return veiculo;
        }

        [HttpGet("cliente/{perfilId}")]
        public ActionResult<List<Veiculo>> GetVeiculoCliente(int perfilId)
        {
            var veiculos = _context.GetVeiculoCliente(perfilId);

            if (veiculos == null)
            {
                return NotFound();
            }

            return veiculos;
        }

        [HttpPost]
        public ActionResult<Veiculo> CriarVeiculo(Veiculo veiculo)
        {
            try
            {
                _context.Adicionar(veiculo);

                return CreatedAtAction(nameof(GetVeiculo), new { id = veiculo.Id }, veiculo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("todos")]
        public ActionResult<List<Veiculo>> GetTodosVeiculos()
        {
            return _context.GetTodos();
        }

        [HttpPut]
        public ActionResult AtualizarPerfil(Veiculo veiculo)
        {
            try
            {
                _context.Atualizar(veiculo.Id, veiculo);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
