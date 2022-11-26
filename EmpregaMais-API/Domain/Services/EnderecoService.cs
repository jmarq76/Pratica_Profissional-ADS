using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Domain.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IRepository _repository;

        public EnderecoService(IRepository repository)
        {
            _repository = repository;
        }

        public void CadastraEndereco(EnderecoModel endereco)
        {
            _repository.Inserir(endereco);
        }

        public void DeletarEndereco(Guid id)
        {
            throw new NotImplementedException();
        }

        public EnderecoModel ObtemEndereco(Guid id)
        {
            return _repository.Obter<EnderecoModel>(e => e.IdUsuario == id);
        }
    }
}
