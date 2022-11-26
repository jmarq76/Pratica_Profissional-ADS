using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Infrastructure.Models;
using Newtonsoft.Json;

namespace Application.Listagens
{
    public class ListagensVagas : IListagemVagas
    {
        private readonly IVagaService _vagaService;
        private readonly IUsuarioService _usuarioService;
        private readonly IScopeContext _scopeContext;

        public ListagensVagas(IVagaService vagaService, IUsuarioService usuarioService, IScopeContext scopeContext)
        {
            _vagaService = vagaService;
            _usuarioService = usuarioService;
            _scopeContext = scopeContext;
        }

        public string OBtemVagasPorChave(string textoBusca)
        {
            var vagas = _vagaService.ObtemVaga(textoBusca);

            var vagasPerfilPj = new List<VagaResponse>();

            foreach(var vaga in vagas)
            {
                var usuario = _usuarioService.ObtemUsuario(u => u.IdPerfil == vaga.IdPerfil);

                var vagaResponse = new VagaResponse()
                {
                    Vaga = vaga,
                    Usuario = usuario
                };

                vagasPerfilPj.Add(vagaResponse);
            }

            return JsonConvert.SerializeObject(vagasPerfilPj);
        }

        public string ObtemVagaPorChave(string textoBusca)
        {
            var vaga = _vagaService.ObtemVagaPorId(textoBusca);

            var vagasPerfilPj = new List<VagaResponse>();

            var usuario = _usuarioService.ObtemUsuario(u => u.IdPerfil == vaga.IdPerfil);

            var vagaResponse = new VagaResponse()
            {
                Vaga = vaga,
                Usuario = usuario
            };

            return JsonConvert.SerializeObject(vagaResponse);
        }

        public VagasEmpresaResponse ListaVagasEmpresa()
        {
            var vagas = _vagaService.ListarVagasPorIdPerfil(_scopeContext.IdPerfil);

            var vagaResponse = new VagasEmpresaResponse();

            foreach(var vaga in vagas)
            {
                if(vaga.DataExpiracao < DateTime.UtcNow && vaga.VagaAtiva == true)
                {
                    vaga.VagaAtiva = false;
                    _vagaService.AtualizaVaga(vaga);
                    vagaResponse.VagasInativas.Add(vaga);
                }
                else if (vaga.VagaAtiva)
                {
                    vagaResponse.VagasAtivas.Add(vaga);
                } else
                {
                    vagaResponse.VagasInativas.Add(vaga);
                }
            }

            return vagaResponse;
        }

        public IEnumerable<VagaModel> ListaVagasAtivasEmpresa()
        {
            return _vagaService.ListarVagasAtivas(_scopeContext.IdPerfil);
        }

        public void CadastrarVagaEmpresa(string vaga)
        {
            var vagaRequest = JsonConvert.DeserializeObject<VagaModel>(vaga);

            vagaRequest.IdPerfil = _scopeContext.IdPerfil;
            vagaRequest.DataExpiracao = vagaRequest.DataExpiracao.ToUniversalTime();
            vagaRequest.VagaAtiva = true;

            _vagaService.CadastraVaga(vagaRequest);
        }
    }
}
