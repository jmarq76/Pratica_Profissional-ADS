using Application.Requests;
using Infrastructure.Models;

namespace Application.Interfaces
{
    public interface IPerfilPfHandler
    {
        PerfilPfModel ObtemPerfil();
        void CadastraDadosPerfilPf(string dadosPerfilPf);
    }
}
