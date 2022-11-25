using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Models;

namespace Application.PerfilPf
{
    public class PerfilPfHandler : IPerfilPfHandler
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IPerfilPfService _perfilPfService;
        private readonly IContatoService _contatoService;
        private readonly IScopeContext _scopeContext;
        private readonly IEnderecoService _enderecoService;

        public PerfilPfHandler(IUsuarioService usuarioService, IPerfilPfService perfilPfService, IMapper mapper, IScopeContext scopeContext, IContatoService contatoService, IEnderecoService enderecoService)
        {
            _usuarioService = usuarioService;
            _perfilPfService = perfilPfService;
            _scopeContext = scopeContext;
            _contatoService = contatoService;
            _enderecoService = enderecoService;
        }

        public PerfilPfModel ObtemPerfil()
        {
            var usuario = _usuarioService.ObtemUsuario(u => u.Id == _scopeContext.Id);

            var contatos = _contatoService.ObtemContato(_scopeContext.Id).ToList();

            var endereco = _enderecoService.ObtemEndereco(_scopeContext.Id);

            usuario.Contatos = contatos;
            usuario.Enderecos = endereco;

            var perfilPf = _perfilPfService.ObtemPerfilPf(_scopeContext.Id);

            perfilPf.Usuario = usuario;

            return perfilPf;
        }
    }
}
