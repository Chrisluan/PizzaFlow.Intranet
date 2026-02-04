using Microsoft.EntityFrameworkCore;
using PizzaFlow.Intranet.Models.Clientes;
using PizzaFlow.Intranet.Models.Pedidos;
using PizzaFlow.Intranet.Models.Produtos;
using PizzaFlow.Intranet.Models.Usuarios;

namespace PizzaFlow.Intranet.Infra
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options){}

        public DbSet<Cliente> Clientes { get; set; } = default!;
        
    }
}
