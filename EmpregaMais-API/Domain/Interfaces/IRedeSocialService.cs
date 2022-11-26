using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface IRedeSocialService
    {
        void CadastrarRedeSocial(RedeSocialModel redeSocial);
        void ObtemRedeSocial(Guid id);
        void DeletarRedeSocial(Guid id);
    }
}
