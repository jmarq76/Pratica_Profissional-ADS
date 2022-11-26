using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface IPerfilPjService
    {
        void CadastrarPerfilPj(PerfilPjModel perfilPj);
        PerfilPjModel ObtemPerfilPj(Guid id);
        void DeletarPerfilPj(Guid id);
    }
}
