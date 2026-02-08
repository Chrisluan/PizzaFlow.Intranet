using Microsoft.AspNetCore.Mvc;
using PizzaFlow.Intranet.Infra;
using PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Models.Clientes;


namespace PizzaFlow.Intranet.Portal.Controllers
{
    [ApiController]
    [Route("test-db")]
    public class TestDbController : ControllerBase
    {
        private readonly Database _context;
        private readonly IClientesRepository clientesRepository;

        public TestDbController(Database context, IClientesRepository clientesRepository)
        {
            this.clientesRepository = clientesRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var podeConectar = await _context.Database.CanConnectAsync();
            return Ok(new { conectado = podeConectar });
        }
        [HttpGet("pegarcliente")]
        public async Task<IActionResult> GetUsersList(int inicio, int max)
        {
            var cliente = clientesRepository.QueryClientes().Skip(inicio).Take(max).ToList();
            return Ok(new {cliente});
        }

        [Route("cadastrar")]
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] Cliente cliente)
        {
            await clientesRepository.CadastrarNovoCliente(cliente);
            return Ok(new { cliente });
        }
        [HttpDelete("deletar/{cliente}")]
        public async Task<IActionResult> Deletar(int cliente)
        {
            var resultado = await clientesRepository.Deletar(cliente);

            if (!resultado)
                return NotFound(new { mensagem = "Cliente não encontrado" });

            return Ok(new {resultado});
        }


    }

}
