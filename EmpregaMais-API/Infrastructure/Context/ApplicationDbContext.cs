using Infrastructure.Context.EntityConfiguration;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new ContatoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DenuncaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IdiomaEnityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LoginEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PerfilPfEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PerfilPjEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VagaUsuarioEntityTypeConfiguration());
        }


        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<DenunciaModel> Denuncias { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<IdiomaModel> Idiomas { get; set; }
        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<PerfilPfModel> PerfilPf { get; set; }
        public DbSet<PerfilPjModel> PerfilPj { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<VagaModel> Vagas { get; set; }
        public DbSet<VagaUsuarioModel> VagasUsuarios { get; set; }
    }
}
