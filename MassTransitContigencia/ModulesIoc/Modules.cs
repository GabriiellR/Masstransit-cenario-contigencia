using MassTransitContigencia.ApplicationSerivce.Interfaces;
using MassTransitContigencia.ApplicationSerivce;
using MassTransitContigencia.Repository;
using MassTransitContigencia.Repository.Interfaces;
using MassTransitContigencia.Consumers;

namespace MassTransitContigencia.ModulesIoc
{
    public static class Modules
    {

        public static void RegisterModules(this IServiceCollection service)
        {
            RegisterTransient(service);
            RegisterSingleton(service);
            RegisterScoped(service);
        }

        private static void RegisterTransient(IServiceCollection service) { }

        private static void RegisterSingleton(IServiceCollection service)
        {
            service.AddSingleton<IRepositoryUsuario, RepositoryUsuario>();
        }

        private static void RegisterScoped(IServiceCollection service)
        {
            service.AddScoped<IApplicationServiceUsuario, ApplicationServiceUsuario>();
        }

    }
}
