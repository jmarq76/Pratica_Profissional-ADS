using Domain.Interfaces;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IPerfilPfService, PerfilPfService>();
            services.AddScoped<IPerfilPjService, PerfilPjService>();

            return services;
        }
    }
}
