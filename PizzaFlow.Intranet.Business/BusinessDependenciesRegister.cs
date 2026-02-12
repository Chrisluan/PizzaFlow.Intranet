
using Microsoft.Extensions.DependencyInjection;
using PizzaFlow.Intranet.Business.Areas.Clientes.Cadastro;
using PizzaFlow.Intranet.Infra;
using PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces;

namespace PizzaFlow.Intranet.Business
{
    public static class BusinessDependenciesRegister
    {

        public static IServiceCollection StartRegister(this IServiceCollection services)
        {
            InfraDependencies.RegisterInfra(services);
            RegisterBusiness(services);
            return services;
        }
        public static IServiceCollection RegisterBusiness(IServiceCollection services)
        {
            
            services.AddScoped<IClientesServices, ClientesServices>();
            services.AddScoped<IClientesRepository, ClientesRepository>();
            
            return services;
        }
    }
}
