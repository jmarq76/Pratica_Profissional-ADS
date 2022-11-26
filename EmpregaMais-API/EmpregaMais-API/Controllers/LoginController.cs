using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace EmpregaMais_API.Controllers
{
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILogin _login;

        public LoginController(ILogin login)
        {
            _login = login;
        }

        [Route("/login")]
        [HttpPost]
        public LoginResponse RealizarLogin([FromBody] JsonObject dadosLogin)
        {
            return _login.RealizarLogin(dadosLogin.ToString());
        }

        [Route("/perfil")]
        [Authorize]
        [HttpGet]
        public void ObtemPerfil()
        {

        }
    }
}
