using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface IEnderecoService
    {
        void CadastraEndereco(EnderecoModel endereco);
        void ObtemEndereco(Guid id);
        void DeletarEndereco(Guid id);
    }
}
