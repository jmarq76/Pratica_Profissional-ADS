using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Infrastructure.Models;
using Newtonsoft.Json;

namespace Application.Handlers
{
    public class VagasHandler : IVagasHandler
    {
        private readonly IVagaService _vagaService;
        private readonly IUsuarioService _usuarioService;
        private readonly IVagaUsuarioService _vagaUsuarioService;
        private readonly IDenunciaService _denunciaService;
        private readonly IScopeContext _scopeContext;

        public VagasHandler(IVagaService vagaService, IUsuarioService usuarioService, IScopeContext scopeContext, IVagaUsuarioService vagaUsuarioService, IDenunciaService denunciaService)
        {
            _vagaService = vagaService;
            _usuarioService = usuarioService;
            _scopeContext = scopeContext;
            _vagaUsuarioService = vagaUsuarioService;
            _denunciaService = denunciaService;
        }

        public string OBtemVagasPorChave(string textoBusca)
        {
            var vagas = _vagaService.ObtemVaga(textoBusca);

            var vagasPerfilPj = new List<VagaResponse>();

            foreach (var vaga in vagas)
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

            foreach (var vaga in vagas)
            {
                if (vaga.DataExpiracao < DateTime.UtcNow && vaga.VagaAtiva == true)
                {
                    vaga.VagaAtiva = false;
                    _vagaService.AtualizaVaga(vaga);
                    vagaResponse.VagasInativas.Add(vaga);
                }
                else if (vaga.VagaAtiva)
                {
                    vagaResponse.VagasAtivas.Add(vaga);
                }
                else
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

        public string CadastrarCurriculoVaga(string dadosCurriculo)
        {
            var vagaUsuario = JsonConvert.DeserializeObject<VagaUsuarioModel>(dadosCurriculo);

            var vagaUsuarioDb = _vagaUsuarioService.VerificaVagaUsuario(vagaUsuario.IdVaga, _scopeContext.IdPerfil);

            if(vagaUsuarioDb != null)
            {
                return "CadastroJaFeito";
            }

            vagaUsuario.IdPerfilPf = _scopeContext.IdPerfil;
            vagaUsuario.DataEnvioPerfilPf = DateTime.UtcNow;

            _vagaUsuarioService.CadastraVagaUsuario(vagaUsuario);

            return "CadastroSucesso";
        }

        public void RealizarDenunciaVaga(string dadosDenuncia)
        {
            var denuncia = JsonConvert.DeserializeObject<DenunciaModel>(dadosDenuncia);

            _denunciaService.CadastraDenuncia(denuncia);
        }

        public IEnumerable<HistoricoVagasResponse> ObterHistoricoVagas()
        {
            var vagasUsuario = _vagaUsuarioService.ListarVagasUsuario(_scopeContext.IdPerfil);

            var listaHistVagas = new List<HistoricoVagasResponse>();
            if(vagasUsuario != null && vagasUsuario.Any())
            {
                foreach(var vagaUsuario in vagasUsuario)
                {
                    var vaga = _vagaService.ObtemVagaPorId(vagaUsuario.IdVaga.ToString());
                    var empresa = _usuarioService.ObtemUsuario(e => e.IdPerfil == vaga.IdPerfil);

                    listaHistVagas.Add(new HistoricoVagasResponse()
                    {
                        Vaga = vaga,
                        VagaUsuario = vagaUsuario,
                        Empresa = empresa
                    });
                }

            }

            return listaHistVagas.Where(lh => lh.Vaga.VagaAtiva);
        }
    }
}
