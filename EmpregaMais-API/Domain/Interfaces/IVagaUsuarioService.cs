using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface IVagaUsuarioService
    {
        void CadastraVagaUsuario(VagaUsuarioModel vagaUsuario);
        void ObtemVagaUsuario(Guid id);
        void DeletaVagaUsuario(Guid id);
    }
}
