using Application.Cadastros;
using Application.Interfaces;
using Application.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICadastroUsuario, CadastroUsuario>();
            services.AddSingleton<IScopeContext, ScopeContext>();

            return services;
        }
    }
}
