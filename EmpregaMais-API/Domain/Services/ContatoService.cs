using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Domain.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IRepository _repository;

        public ContatoService(IRepository repository)
        {
            _repository = repository;
        }

        public void CadastraContato(ContatoModel contato)
        {
            _repository.Inserir(contato);
        }

        public void DeletaContato(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContatoModel> ObtemContato(Guid id)
        {
            return _repository.ListarTodosPorChave<ContatoModel>(c => c.IdUsuario == id);
        }
    }
}
