using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface IHistoricoAcademicoService
    {
        void CadastrarHistoricoAcademico(HistoricoAcademicoModel historicoAcademico);
        IEnumerable<HistoricoAcademicoModel> ObtemHistoricosAcademicos(Guid idPerfil);
        void DeletarHistoricoAcademico(Guid id);
        void AtualizarHistoricoAcademico(HistoricoAcademicoModel historicoAcademico);
    }
}
