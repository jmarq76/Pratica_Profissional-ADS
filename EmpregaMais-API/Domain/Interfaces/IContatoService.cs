using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface IContatoService
    {
        void CadastraContato(ContatoModel contato);
        void ObtemContato(Guid id);
        void DeletaContato(Guid id);
    }
}
