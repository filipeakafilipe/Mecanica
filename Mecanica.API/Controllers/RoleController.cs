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
    public class RoleController : ControllerBase
    {
        private RoleRepositorio _context;

        public RoleController()
        {
            _context = new RoleRepositorio();
        }

        [HttpGet()]
        public ActionResult<List<Role>> GetTodos()
        {
            return _context.GetTodos();
        }
    }
}
