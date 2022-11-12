using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class HistoricoProfissionalEntityTypeConfiguration : IEntityTypeConfiguration<HistoricoProfissionalModel>
    {
        public void Configure(EntityTypeBuilder<HistoricoProfissionalModel> builder)
        {
            builder
                .HasOne<PerfilPfModel>()
                .WithMany(p => p.HistoricosProfissionais)
                .HasForeignKey(h => h.IdPerfil);
        }
    }
}
