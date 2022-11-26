using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface IDenunciaService
    {
        void CadastraDenuncia(DenunciaModel denuncia);
        void ObtemDenuncia(Guid id);
        void DeletaDenuncia(Guid id);
    }
}
