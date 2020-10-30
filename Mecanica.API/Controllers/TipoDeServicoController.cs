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
    public class TipoDeServicoController : ControllerBase
    {
        private readonly ITipoDeServicoRepository<TipoDeServico> _context;

        //private TipoDeServicoRepositorio _context;

        public TipoDeServicoController(ITipoDeServicoRepository<TipoDeServico> context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<TipoDeServico> GetTipoDeServico(int id)
        {
            var tipoDeServico = _context.Get(id);

            if (tipoDeServico == null)
            {
                return NotFound();
            }

            return tipoDeServico;
        }

        [HttpPost]
        public ActionResult<TipoDeServico> CriarPerfil(TipoDeServico tipoDeServico)
        {
            try
            {
                _context.Adicionar(tipoDeServico);

                return CreatedAtAction(nameof(GetTipoDeServico), new { id = tipoDeServico.Id }, tipoDeServico);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("todos")]
        public ActionResult<List<TipoDeServico>> GetTodosTipoDeServicos()
        {
            return _context.GetTodos();
        }

        [HttpPut]
        public ActionResult AtualizarTipoDeServico(TipoDeServico tipoDeServico)
        {
            try
            {
                _context.Atualizar(tipoDeServico.Id, tipoDeServico);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
