using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Domain.Services
{
    public class HistoricoAcademicoService : IHistoricoAcademicoService
    {
        private readonly IRepository _repository;
        public HistoricoAcademicoService(IRepository repository)
        {
            _repository = repository;
        }

        public void AtualizarHistoricoAcademico(HistoricoAcademicoModel historicoAcademico)
        {
            historicoAcademico.Id = _repository.Obter<HistoricoAcademicoModel>(hist => hist.IdPerfil == historicoAcademico.IdPerfil).Id;
            _repository.Atualizar(historicoAcademico);
        }

        public void CadastrarHistoricoAcademico(HistoricoAcademicoModel historicoAcademico)
        {
            _repository.Inserir(historicoAcademico);
        }

        public void DeletarHistoricoAcademico(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HistoricoAcademicoModel> ObtemHistoricosAcademicos(Guid idPerfil)
        {
            return _repository.ListarTodosPorChave<HistoricoAcademicoModel>(hist => hist.IdPerfil == idPerfil);
        }
    }
}
