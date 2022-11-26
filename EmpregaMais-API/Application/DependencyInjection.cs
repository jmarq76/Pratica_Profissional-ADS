using Application.Cadastros;
using Application.Interfaces;
using Application.Listagens;
using Application.LoginHandler;
using Application.PerfilPf;
using Application.Utils;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICadastroUsuario, CadastroUsuario>();
            services.AddScoped<ICadastroVaga, CadastroVaga>();
            services.AddScoped<ICadastroDenuncia, CadastroDenuncia>();
            services.AddScoped<IListagemVagas, ListagensVagas>();
            services.AddScoped<ILogin, Login>();
            services.AddScoped<IPerfilPfHandler, PerfilPfHandler>();
            services.AddSingleton<IScopeContext, ScopeContext>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
