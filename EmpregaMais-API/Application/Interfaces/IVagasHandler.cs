using Application.Responses;
using Infrastructure.Models;
using System.Text.Json.Nodes;

namespace Application.Interfaces
{
    public interface IVagasHandler
    {
        string OBtemVagasPorChave(string textoBusca);
        string ObtemVagaPorChave(string textoBusca);
        VagasEmpresaResponse ListaVagasEmpresa();
        void CadastrarVagaEmpresa(string vaga);
        IEnumerable<VagaModel> ListaVagasAtivasEmpresa();
        string CadastrarCurriculoVaga(string dadosCurriculo);
        void RealizarDenunciaVaga(string dadosDenuncia);
        IEnumerable<HistoricoVagasResponse> ObterHistoricoVagas();
    }
}
