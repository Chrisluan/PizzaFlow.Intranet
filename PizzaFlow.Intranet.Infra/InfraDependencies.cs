
using Microsoft.Extensions.DependencyInjection;
using PizzaFlow.Intranet.Business.PizzaFlowBase;
using PizzaFlow.Intranet.Business.PizzaFlowBase.Repository;
using PizzaFlow.Intranet.Business.PizzaFlowBase.Repository.Interfaces;
namespace PizzaFlow.Intranet.Infra
{
    public static class InfraDependencies
    {

        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            DependencyInjectionTypes.RegisterTypes(services);
            services.AddScoped(typeof(IDataRepository<>), typeof(DataRepository<>));
            return services;
        }

    }
}
