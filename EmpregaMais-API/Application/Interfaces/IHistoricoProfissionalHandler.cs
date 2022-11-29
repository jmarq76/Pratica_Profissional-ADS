using Infrastructure.Models;

namespace Application.Interfaces
{
    public interface IHistoricoProfissionalHandler
    {
        void CadastraAtualizaHistoricoProfissional(string dadosHistProfissional);
        IEnumerable<HistoricoProfissionalModel> ObtemHistoricosProfissionais();
    }
}
