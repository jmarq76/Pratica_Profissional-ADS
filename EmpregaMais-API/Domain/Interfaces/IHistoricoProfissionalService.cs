using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface IHistoricoProfissionalService
    {
        void CadastrarHistoricoProfissional(HistoricoProfissionalModel historicoProfissional);
        IEnumerable<HistoricoProfissionalModel> ObtemHistoricosProfssionais(Guid idPerfil);
        void DeletarHistoricoAcademico(Guid id);
        void AtualizarHistoricoProfissional(HistoricoProfissionalModel historicoProfissional);
    }
}
