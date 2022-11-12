using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Domain.Services
{
    public class PerfilPfService : IPerfilPfService
    {
        private readonly IRepository _repository;

        public PerfilPfService(IRepository repository)
        {
            _repository = repository;
        }

        public void CadastraPerfilPf(PerfilPfModel perfilPf)
        {
            _repository.Inserir(perfilPf);
        }

        public void DeletaPerfilPf(Guid id)
        {
            throw new NotImplementedException();
        }

        public void ObtemPerfilPf(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
