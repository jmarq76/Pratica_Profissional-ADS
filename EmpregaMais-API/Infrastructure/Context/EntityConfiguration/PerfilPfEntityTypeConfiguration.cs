using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class PerfilPfEntityTypeConfiguration : IEntityTypeConfiguration<PerfilPfModel>
    {
        public void Configure(EntityTypeBuilder<PerfilPfModel> builder)
        {
            builder
                .HasOne<UsuarioModel>()
                .WithOne(u => u.PerfilPf)
                .HasForeignKey<PerfilPfModel>(pf => pf.IdUsuario);
        }
    }
}
