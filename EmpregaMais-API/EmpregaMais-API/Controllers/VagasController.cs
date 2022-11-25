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
        private readonly IListagemVagas _listagemVagas;

        public VagasController(IListagemVagas listagemVagas)
        {
            _listagemVagas = listagemVagas;
        }

        [Route("/vagas/busca")]
        [HttpGet]
        public string BuscaVagas([FromQuery]string textoBusca)
        {
            return _listagemVagas.OBtemVagasPorChave(textoBusca);
        }

        [Route("/vagas/buscaVaga")]
        [HttpGet]
        public string BuscaVaga([FromQuery] string textoBusca)
        {
            return _listagemVagas.ObtemVagaPorChave(textoBusca);
        }

        [Route("/vagas/listaVagasEmpresa")]
        [Authorize]
        [HttpGet]
        public VagasEmpresaResponse ListaVagasEmpresa()
        {
            return _listagemVagas.ListaVagasEmpresa();
        }

        [Route("/empresa/vagas/ativas")]
        [Authorize]
        [HttpGet]
        public IEnumerable<VagaModel> ListaVagasAtivasEmpresa()
        {
            return _listagemVagas.ListaVagasAtivasEmpresa();
        }

        [Route("/empresa/cadastravaga")]
        [Authorize]
        [HttpPost]
        public void CadastraVagaEmpresa([FromBody] JsonObject vaga)
        {
            _listagemVagas.CadastrarVagaEmpresa(vaga.ToString());
        }
    }
}
