using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface IUsuarioService
    {
        void CadastraUsuario(UsuarioModel usuario);
        void ObtemUsuario(Guid id);
        void DeletaUsuario(Guid id);
    }
}
