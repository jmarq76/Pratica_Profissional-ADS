using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface IHistoricoAcademicoService
    {
        void CadastrarHistoricoAcademico(HistoricoAcademicoModel historicoAcademico);
        void ObtemHistoricoAcadamento(Guid id);
        void DeletarHistoricoAcademico(Guid id);
    }
}
