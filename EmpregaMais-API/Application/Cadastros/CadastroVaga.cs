using Application.Interfaces;
using Domain.Interfaces;
using Infrastructure.Models;

namespace Application.Cadastros
{
    public class CadastroVaga : ICadastroVaga
    {
        private readonly IVagaService _vagaService;

        public CadastroVaga(IVagaService vagaService)
        {
            _vagaService = vagaService;
        }

        public void RealizaCadastroVaga(VagaModel vaga)
        {
            _vagaService.CadastraVaga(vaga);
        }
    }
}
