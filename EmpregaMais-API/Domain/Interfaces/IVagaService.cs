using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface IVagaService
    {
        void CadastraVaga(VagaModel vaga);
        IEnumerable<VagaModel> ObtemVaga(string textoBusca);
        VagaModel ObtemVagaPorId(string textoBusca);
        void DeletarVaga(Guid id);
        IEnumerable<VagaModel> ListarVagasPorIdPerfil(Guid idPerfil);
        void AtualizaVaga(VagaModel vaga);
        IEnumerable<VagaModel> ListarVagasAtivas(Guid idPerfil);
    }
}
