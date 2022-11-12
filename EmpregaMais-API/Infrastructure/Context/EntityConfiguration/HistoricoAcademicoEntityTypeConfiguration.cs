using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class HistoricoAcademicoEntityTypeConfiguration : IEntityTypeConfiguration<HistoricoAcademicoModel>
    {
        public void Configure(EntityTypeBuilder<HistoricoAcademicoModel> builder)
        {
            builder
                .HasOne<PerfilPfModel>()
                .WithMany(p => p.HistoricosAcademicos)
                .HasForeignKey(h => h.IdPerfil);
        }
    }
}
