using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Domain.Services
{
    public class VagaService : IVagaService
    {
        private readonly IRepository _repository;

        public VagaService(IRepository repository)
        {
            _repository = repository;
        }

        public void CadastraVaga(VagaModel vaga)
        {
            _repository.Inserir(vaga);
        }

        public void DeletarVaga(Guid id)
        {
            throw new NotImplementedException();
        }

        public void ObtemVaga(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
