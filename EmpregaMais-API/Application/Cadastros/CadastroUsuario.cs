using Application.Interfaces;
using Application.Requests;
using Application.Utils;
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

        public CadastroUsuario(
            ILoginService loginService, 
            IUsuarioService usuarioService, 
            IContatoService contatoService, 
            IEnderecoService enderecoService, 
            IPerfilPfService perfilPfService, 
            IPerfilPjService perfilPjService)
        {
            _loginService = loginService;
            _usuarioService = usuarioService;
            _contatoService = contatoService;
            _enderecoService = enderecoService;
            _perfilPfService = perfilPfService;
            _perfilPjService = perfilPjService;
        }
        public void RealizaCadastro(string json)
        {
            try
            {
                var dadosCadastro = JsonConvert.DeserializeObject<CadastroRequest>(json);

                dadosCadastro.Login.Id = Guid.NewGuid();
                dadosCadastro.Usuario.Id = Guid.NewGuid();
                dadosCadastro.Usuario.IdLogin = dadosCadastro.Login.Id;
                dadosCadastro.Login.IdUsuario = dadosCadastro.Usuario.Id;

                PreparaCadastroLogin(dadosCadastro.Login);
                PrepararCadastroUsuario(dadosCadastro.Usuario);
                PrepararCadastroContatos(dadosCadastro.Contatos, dadosCadastro.Usuario.Id);
                PrepararCadastroEnderecos(dadosCadastro.Enderecos, dadosCadastro.Usuario.Id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void PrepararCadastroEnderecos(List<EnderecoModel> enderecos, Guid usuarioId)
        {
            foreach(var endereco in enderecos)
            {
                endereco.IdUsuario = usuarioId;
                _enderecoService.CadastraEndereco(endereco);
            }
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
                var userNameEncrypt = CryptoEngine.EncryptPlainTextToCypher(login.NomeUsuario, login.Password);
                var passwordEncrypt = CryptoEngine.EncryptPlainTextToCypher(login.Password, login.NomeUsuario);
                login.NomeUsuario = userNameEncrypt;
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
