namespace PizzaFlow.Intranet.Models.Usuarios
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int GrupoUsuarioId { get; set; }
        public GrupoUsuario GrupoUsuario { get; set; }
    }
}
