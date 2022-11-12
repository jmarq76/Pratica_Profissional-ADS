using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ContatoModel> Contatos { get; set; }
        DbSet<DenunciaModel> Denuncias { get; set; }
        DbSet<EnderecoModel> Enderecos { get; set; }
        DbSet<HistoricoAcademicoModel> HistoricosAcademicos { get; set; }
        DbSet<HistoricoProfissionalModel> HistoricosProfissionais { get; set; }
        DbSet<IdiomaModel> Idiomas { get; set; }
        DbSet<LoginModel> Logins { get; set; }
        DbSet<PerfilPfModel> PerfilPf { get; set; }
        DbSet<PerfilPjModel> PerfilPj { get; set; }
        DbSet<RedeSocialModel> RedesSociais { get; set; }
        DbSet<UsuarioModel> Usuarios { get; set; }
        DbSet<VagaModel> Vagas { get; set; }
        DbSet<VagaUsuarioModel> VagasUsuarios { get; set; }
    }
}
