using Application.Helper;
using Application.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace EmpregaMais_API.Controllers
{
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IPerfilPfHandler _perfilHandler;
        private readonly IHistoricoAcademicoHandler _historicoAcademicoHandler;
        private readonly IHistoricoProfissionalHandler _historicoProfissionalHandler;

        public UsuarioController(IPerfilPfHandler perfilHandler, IHistoricoAcademicoHandler historicoAcademicoHandler, IHistoricoProfissionalHandler historicoProfisionalHandler)
        {
            _perfilHandler = perfilHandler;
            _historicoAcademicoHandler = historicoAcademicoHandler;
            _historicoProfissionalHandler = historicoProfisionalHandler;
        }

        [Route("/perfilpf/busca")]
        [Authorize]
        [HttpGet]
        public PerfilPfModel ObtemPerfilPf()
        {
            return _perfilHandler.ObtemPerfil();
        }

        [Route("/perfilpj/busca")]
        [Authorize]
        [HttpGet]
        public PerfilPfModel ObtemPerfilPj()
        {
            return _perfilHandler.ObtemPerfil();
        }

        [Route("/perfilpf/gravarperfil")]
        [Authorize]
        [HttpPost]
        public void CadastraDadosPerfilPf([FromBody] JsonObject dadosPerfilPf)
        {
            _perfilHandler.CadastraDadosPerfilPf(dadosPerfilPf.ToString());
        }

        [Route("/perfilpf/gravarhistacademico")]
        [Authorize]
        [HttpPost]
        public void CadastroAtualizaHistoricoAcademico([FromBody] JsonArray dadosHistAcademico)
        {
            _historicoAcademicoHandler.CadastrarAtualizarHistoricoAcademico(dadosHistAcademico.ToString());
        }

        [Route("/perfilpf/obterhistoricosacademicos")]
        [Authorize]
        [HttpGet]
        public IEnumerable<HistoricoAcademicoModel> ObtemHistoricosAcademicos()
        {
            return _historicoAcademicoHandler.ObterHistoricosAcademicos();
        }

        [Route("/perfilpf/gravarhistprofissional")]
        [Authorize]
        [HttpPost]
        public void CadastroAtualizaHistoricoProfissional([FromBody] JsonArray dadosHistAcademico)
        {
            _historicoProfissionalHandler.CadastraAtualizaHistoricoProfissional(dadosHistAcademico.ToString());
        }

        [Route("/perfilpf/obterhistoricosprofissionais")]
        [Authorize]
        [HttpGet]
        public IEnumerable<HistoricoProfissionalModel> ObtemHistoricosProfissionais()
        {
            return _historicoProfissionalHandler.ObtemHistoricosProfissionais();
        }
    }
}
