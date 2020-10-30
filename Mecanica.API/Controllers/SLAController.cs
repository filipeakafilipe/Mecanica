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
    public class SLAController : ControllerBase
    {
        private SLARepositorio _context;

        public SLAController()
        {
            _context = new SLARepositorio();
        }

        [HttpGet()]
        public ActionResult<List<SLA>> GetTodos()
        {
            return _context.GetTodos();
        }
    }
}
