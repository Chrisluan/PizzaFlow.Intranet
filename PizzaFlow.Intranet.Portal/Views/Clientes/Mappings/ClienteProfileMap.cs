using AutoMapper;
using PizzaFlow.Intranet.Models.Clientes;
using PizzaFlow.Intranet.ViewModels.Clientes;

namespace PizzaFlow.Intranet.Portal.Views.Clientes.Mappings
{
    public class ClienteProfileMap : Profile
    {
        public ClienteProfileMap() {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
        }
    }
}
