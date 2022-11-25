using Application.Responses;
using Infrastructure.Models;
using System.Text.Json.Nodes;

namespace Application.Interfaces
{
    public interface IListagemVagas
    {
        string OBtemVagasPorChave(string textoBusca);
        string ObtemVagaPorChave(string textoBusca);
        VagasEmpresaResponse ListaVagasEmpresa();
        void CadastrarVagaEmpresa(string vaga);
        IEnumerable<VagaModel> ListaVagasAtivasEmpresa();
    }
}
