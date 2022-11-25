using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Domain.Services
{
    public class PerfilPjService : IPerfilPjService
    {
        private readonly IRepository _repository;

        public PerfilPjService(IRepository repository)
        {
            _repository = repository;
        }

        public void CadastrarPerfilPj(PerfilPjModel perfilPj)
        {
            _repository.Inserir(perfilPj);
        }

        public void DeletarPerfilPj(Guid id)
        {
            throw new NotImplementedException();
        }

        public PerfilPjModel ObtemPerfilPj(Guid id)
        {
            return _repository.Obter<PerfilPjModel>(pj => pj.Id == id);
        }
    }
}
