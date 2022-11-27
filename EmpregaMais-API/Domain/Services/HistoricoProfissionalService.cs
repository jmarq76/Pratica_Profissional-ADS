using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Domain.Services
{
    public class HistoricoProfissionalService : IHistoricoProfissionalService
    {
        private readonly IRepository _repository;
        public HistoricoProfissionalService(IRepository repository)
        {
            _repository = repository;
        }

        public void AtualizarHistoricoProfissional(HistoricoProfissionalModel historicoProfissional)
        {
            historicoProfissional.Id = _repository.Obter<HistoricoProfissionalModel>(hist => hist.IdPerfil == historicoProfissional.IdPerfil).Id;
            _repository.Atualizar(historicoProfissional);
        }

        public void CadastrarHistoricoProfissional(HistoricoProfissionalModel historicoProfissional)
        {
            _repository.Inserir(historicoProfissional);
        }

        public void DeletarHistoricoAcademico(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HistoricoProfissionalModel> ObtemHistoricosProfssionais(Guid idPerfil)
        {
            return _repository.ListarTodosPorChave<HistoricoProfissionalModel>(hist => hist.IdPerfil == idPerfil);
        }
    }
}
