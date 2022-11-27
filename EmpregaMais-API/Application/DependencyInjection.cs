using Application.Cadastros;
using Application.Handlers;
using Application.Interfaces;
using Application.LoginHandler;
using Application.Utils;
using Domain.Interfaces;
using Domain.Services;
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
            services.AddScoped<IVagasHandler, VagasHandler>();
            services.AddScoped<ILogin, Login>();
            services.AddScoped<IPerfilPfHandler, PerfilPfHandler>();
            services.AddScoped<IHistoricoAcademicoHandler, HistoricoAcademicoHandler>();
            services.AddScoped<IHistoricoProfissionalHandler, HistoricoProfissionalHandler>();
            services.AddScoped<IVagaUsuarioService, VagaUsuarioService>();
            services.AddSingleton<IScopeContext, ScopeContext>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
