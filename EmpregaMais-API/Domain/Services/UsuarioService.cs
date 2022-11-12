using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepository _repository;

        public UsuarioService(IRepository repository)
        {
            _repository = repository;
        }

        public void CadastraUsuario(UsuarioModel usuario)
        {
            _repository.Inserir(usuario);
        }

        public void DeletaUsuario(Guid id)
        {
            throw new NotImplementedException();
        }

        public void ObtemUsuario(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
