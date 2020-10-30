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
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilRepository<Perfil> _context;

        public PerfilController(IPerfilRepository<Perfil> context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Perfil> GetPerfil(int id)
        {
            var perfil = _context.Get(id);

            if (perfil == null)
            {
                return NotFound();
            }

            return perfil;
        }

        [HttpGet("todos")]
        public ActionResult<List<Perfil>> GetTodosPerfis()
        {
            return _context.GetTodos();
        }

        [HttpPost]
        public ActionResult<Perfil> CriarPerfil(Perfil perfil)
        {
            if (_context.Get(perfil.Login) != null)
            {
                return BadRequest();
            }

            try
            {
                _context.Adicionar(perfil);

                return CreatedAtAction(nameof(GetPerfil), new { id = perfil.Id }, perfil);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult AtualizarPerfil(Perfil perfil)
        {
            try
            {
                _context.Atualizar(perfil.Id, perfil);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("logar/{login}/{senha}")]
        public ActionResult<Perfil> Logar(string login, string senha)
        {
            var usuario = _context.Login(login, senha);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }
    }
}
