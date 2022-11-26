using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface IHistoricoProfissionalService
    {
        void CadastrarHistoricoProfissional(HistoricoProfissionalModel historicoProfissional);
        void ObtemHistoricoProfssional(Guid id);
        void DeletarHistoricoAcademico(Guid id);
    }
}
