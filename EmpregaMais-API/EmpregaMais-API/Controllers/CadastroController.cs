using Application.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace EmpregaMais_API.Controllers
{
    [ApiController]
    public class CadastroController : Controller
    {
        private readonly ICadastroUsuario _cadastroUsuario;
        private readonly ICadastroVaga _cadastroVaga;
        private readonly ICadastroDenuncia _cadastroDenuncia;

        public CadastroController(ICadastroUsuario cadastroUsuario, ICadastroVaga cadastroVaga, ICadastroDenuncia cadastroDenuncia)
        {
            _cadastroUsuario = cadastroUsuario;
            _cadastroVaga = cadastroVaga;
            _cadastroDenuncia = cadastroDenuncia;
        }
        [Route("/cadastro/usuario")]
        [HttpPost]
        public IActionResult CadastroUsuario([FromBody] JsonObject dados)
        {
            try
            {
                _cadastroUsuario.RealizaCadastro(dados.ToString());
                return new OkResult();
            }
            catch
            {
                return new BadRequestResult();
            }
        }

        [Route("/cadastro/empresa")]
        [HttpPost]
        public IActionResult CadastroEmpresa([FromBody] JsonObject dados)
        {
            try
            {
                _cadastroUsuario.RealizaCadastro(dados.ToString());
                return new OkResult();
            }
            catch
            {
                return new BadRequestResult();
            }
        }

        [Route("/cadastro/vaga")]
        [HttpPost]
        public void CadastroVaga([FromBody] VagaModel vaga)
        {
            _cadastroVaga.RealizaCadastroVaga(vaga);
        }

        [Route("/cadastro/denuncia")]
        [HttpPost]
        public void CadastroDenuncia([FromBody] DenunciaModel denuncia)
        {
            _cadastroDenuncia.FazerCadastroDenuncia(denuncia);
        }
    }
}
