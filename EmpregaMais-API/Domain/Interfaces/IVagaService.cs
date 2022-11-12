using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface IVagaService
    {
        void CadastraVaga(VagaModel vaga);
        void ObtemVaga(Guid id);
        void DeletarVaga(Guid id);
    }
}
