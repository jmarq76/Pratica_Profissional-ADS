using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Domain.Services
{
    public class DenunciaService : IDenunciaService
    {
        private readonly IRepository _repoistory;

        public DenunciaService(IRepository repoistory)
        {
            _repoistory = repoistory;
        }

        public void CadastraDenuncia(DenunciaModel denuncia)
        {
            _repoistory.Inserir(denuncia);
        }

        public void DeletaDenuncia(Guid id)
        {
            throw new NotImplementedException();
        }

        public void ObtemDenuncia(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
