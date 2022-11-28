using Application.Helper;
using Application.Interfaces;
using Application.Responses;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace EmpregaMais_API.Controllers
{
    [ApiController]
    public class VagasController : Controller
    {
        private readonly IVagasHandler _vagasHandler;

        public VagasController(IVagasHandler vagasHandler)
        {
            _vagasHandler = vagasHandler;
        }

        [Route("/vagas/busca")]
        [HttpGet]
        public string BuscaVagas([FromQuery] string textoBusca)
        {
            return _vagasHandler.OBtemVagasPorChave(textoBusca);
        }

        [Route("/vagas/buscaVaga")]
        [HttpGet]
        public string BuscaVaga([FromQuery] string textoBusca)
        {
            return _vagasHandler.ObtemVagaPorChave(textoBusca);
        }

        [Route("/vagas/listaVagasEmpresa")]
        [Authorize]
        [HttpGet]
        public VagasEmpresaResponse ListaVagasEmpresa()
        {
            return _vagasHandler.ListaVagasEmpresa();
        }

        [Route("/empresa/vagas/ativas")]
        [Authorize]
        [HttpGet]
        public IEnumerable<VagaModel> ListaVagasAtivasEmpresa()
        {
            return _vagasHandler.ListaVagasAtivasEmpresa();
        }

        [Route("/empresa/cadastravaga")]
        [Authorize]
        [HttpPost]
        public void CadastraVagaEmpresa([FromBody] JsonObject vaga)
        {
            _vagasHandler.CadastrarVagaEmpresa(vaga.ToString());
        }

        [Route("/perfilpf/enviarcurriculo")]
        [Authorize]
        [HttpPost]
        public string EnviarCurriculo([FromBody] JsonObject dadosVaga)
        {
            return _vagasHandler.CadastrarCurriculoVaga(dadosVaga.ToString());
        }

        [Route("/denunciaVaga")]
        [Authorize]
        [HttpPost]
        public void RealizarDenunciaVaga([FromBody] JsonObject dadosDenuncia)
        {
            _vagasHandler.RealizarDenunciaVaga(dadosDenuncia.ToString());
        }

        [Route("/perfilpf/historicovagas")]
        [Authorize]
        [HttpGet]
        public IEnumerable<HistoricoVagasResponse> ObterHistoricoVagas()
        {
            return _vagasHandler.ObterHistoricoVagas();
        }
    }
}
