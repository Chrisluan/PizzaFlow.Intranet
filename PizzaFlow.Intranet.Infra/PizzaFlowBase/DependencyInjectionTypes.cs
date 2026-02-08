using Microsoft.Extensions.DependencyInjection;
using PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository;
using PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces;

namespace PizzaFlow.Intranet.Business.PizzaFlowBase
{
    public static class DependencyInjectionTypes
    {
        public static void RegisterTypes(IServiceCollection services)
        {
            services.AddScoped<IClientesRepository,ClientesRepository>();
        }
    }
}
