using Application.Interfaces;
using Domain.Interfaces;
using Infrastructure.Models;

namespace Application.Cadastros
{
    public class CadastroDenuncia : ICadastroDenuncia
    {
        private readonly IDenunciaService _denunciaService;

        public CadastroDenuncia(IDenunciaService denunciaService)
        {
            _denunciaService = denunciaService;
        }

        public void FazerCadastroDenuncia(DenunciaModel denuncia)
        {
            _denunciaService.CadastraDenuncia(denuncia);
        }
    }
}
