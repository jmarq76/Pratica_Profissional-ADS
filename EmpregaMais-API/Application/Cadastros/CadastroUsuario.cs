using Application.Interfaces;
using Application.Requests;
using Application.Utils;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Enums;
using Infrastructure.Models;
using Newtonsoft.Json;

namespace Application.Cadastros
{
    public class CadastroUsuario : ICadastroUsuario
    {
        private readonly ILoginService _loginService;
        private readonly IUsuarioService _usuarioService;
        private readonly IContatoService _contatoService;
        private readonly IEnderecoService _enderecoService;
        private readonly IPerfilPfService _perfilPfService;
        private readonly IPerfilPjService _perfilPjService;
        private readonly IMapper _mapper;

        public CadastroUsuario(
            ILoginService loginService, 
            IUsuarioService usuarioService, 
            IContatoService contatoService, 
            IEnderecoService enderecoService, 
            IPerfilPfService perfilPfService, 
            IPerfilPjService perfilPjService,
            IMapper mapper)
        {
            _loginService = loginService;
            _usuarioService = usuarioService;
            _contatoService = contatoService;
            _enderecoService = enderecoService;
            _perfilPfService = perfilPfService;
            _perfilPjService = perfilPjService;
            _mapper = mapper;
        }
        public void RealizaCadastro(string json)
        {
            try
            {
                var dadosCadastro = JsonConvert.DeserializeObject<CadastroRequest>(json);

                var login = _mapper.Map<CadastroRequest, LoginModel>(dadosCadastro);
                var usuario = _mapper.Map<CadastroRequest, UsuarioModel>(dadosCadastro);
                var contatos = new List<ContatoModel>()
                {
                    new ContatoModel()
                    {
                        Descricao = dadosCadastro.Celular,
                        TipoContato = TipoContato.Celular
                    },
                    new ContatoModel()
                    {
                        Descricao = dadosCadastro.Telefone,
                        TipoContato = TipoContato.TelefoneFixo,
                    }
                };
                var endereco = _mapper.Map<CadastroRequest, EnderecoModel>(dadosCadastro);

                login.Id = Guid.NewGuid();
                usuario.Id = Guid.NewGuid();
                usuario.IdLogin = login.Id;
                login.IdUsuario = usuario.Id;

                PreparaCadastroLogin(login);
                PrepararCadastroUsuario(usuario);
                PrepararCadastroContatos(contatos, usuario.Id);
                PrepararCadastroEnderecos(endereco, usuario.Id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void PrepararCadastroEnderecos(EnderecoModel endereco, Guid usuarioId)
        {
                endereco.IdUsuario = usuarioId;
                _enderecoService.CadastraEndereco(endereco);

        }

        private void PrepararCadastroContatos(List<ContatoModel> contatos, Guid usuarioId)
        {
            foreach(var contato in contatos)
            {
                contato.IdUsuario = usuarioId;
                _contatoService.CadastraContato(contato);
            }
        }

        private void PrepararCadastroUsuario(UsuarioModel usuario)
        {
            usuario.IdPerfil = Guid.NewGuid();
            _usuarioService.CadastraUsuario(usuario);

            if (usuario.TipoUsuario.Equals(TipoUsuario.PessoaFisica))
            {
                var perfilPf = new PerfilPfModel();
                perfilPf.Id = usuario.IdPerfil.Value;
                perfilPf.IdUsuario = usuario.Id;
                _perfilPfService.CadastraPerfilPf(perfilPf);
            }
            else
            {
                var perfilPj = new PerfilPjModel();
                perfilPj.Id = usuario.IdPerfil.Value;
                perfilPj.IdUsuario = usuario.Id;
                _perfilPjService.CadastrarPerfilPj(perfilPj);
            }
        }

        private void PreparaCadastroLogin(LoginModel login)
        {
            try
            {
                var passwordEncrypt = CryptoEngine.EncryptPlainTextToCypher(login.Password, login.NomeUsuario);
                login.Password = passwordEncrypt;

                _loginService.CadastrarLogin(login);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
