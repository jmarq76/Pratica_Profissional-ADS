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

        public IEnumerable<VagaModel> ObtemVaga(string textoBusca)
        {
            return _repository.ListarTodosPorChave<VagaModel>(v => v.Titulo.Contains(textoBusca) || v.Descricao.Contains(textoBusca) && v.VagaAtiva == true).OrderByDescending(v => v.DataCriacao);
        }

        public VagaModel ObtemVagaPorId(string textoBusca)
        {
            return _repository.Obter<VagaModel>(v => v.Id == Guid.Parse(textoBusca));
        }

        public IEnumerable<VagaModel> ListarVagasPorIdPerfil(Guid idPerfil)
        {
            return _repository.ListarTodosPorChave<VagaModel>(v => v.IdPerfil == idPerfil);
        }

        public IEnumerable<VagaModel> ListarVagasAtivas(Guid idPerfil)
        {
            return _repository.ListarTodosPorChave<VagaModel>(v => v.IdPerfil == idPerfil).Where(v => v.VagaAtiva == true);
        }

        public void AtualizaVaga(VagaModel vaga)
        {
            _repository.Atualizar(vaga);
        }
    }
}
