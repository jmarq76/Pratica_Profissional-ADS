using Infrastructure.Models;

namespace Application.Interfaces
{
    public interface IHistoricoAcademicoHandler
    {
        void CadastrarAtualizarHistoricoAcademico(string dadosHistAcademico);
        IEnumerable<HistoricoAcademicoModel> ObterHistoricosAcademicos();
    }
}
