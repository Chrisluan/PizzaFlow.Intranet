using Microsoft.AspNetCore.Mvc;
using PizzaFlow.Intranet.Infra;
using System;

namespace PizzaFlow.Intranet.Portal.Controllers
{
    [ApiController]
    [Route("test-db")]
    public class TestDbController : ControllerBase
    {
        private readonly Database _context;

        public TestDbController(Database context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var podeConectar = await _context.Database.CanConnectAsync();
            return Ok(new { conectado = podeConectar });
        }
    }

}
