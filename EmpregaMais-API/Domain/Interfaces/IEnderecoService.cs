using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface IEnderecoService
    {
        void CadastraEndereco(EnderecoModel endereco);
        EnderecoModel ObtemEndereco(Guid id);
        void DeletarEndereco(Guid id);
    }
}
