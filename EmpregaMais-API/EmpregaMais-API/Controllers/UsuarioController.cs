using Application.Helper;
using Application.Interfaces;
using Application.Responses;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpregaMais_API.Controllers
{
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IPerfilPfHandler _perfilHandler;

        public UsuarioController(IPerfilPfHandler perfilHandler)
        {
            _perfilHandler = perfilHandler;
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
    }
}
