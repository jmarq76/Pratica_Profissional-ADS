using Application.Helper;
using Application.Interfaces;
using Application.Requests;
using Application.Responses;
using Application.Utils;
using Domain.Interfaces;
using Infrastructure.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.LoginHandler
{
    public class Login : ILogin
    {
        private readonly ILoginService _loginService;
        private readonly IUsuarioService _usuarioService;
        private readonly AppSettings _appSettings;

        public Login(ILoginService loginService, IOptions<AppSettings> appSettings, IUsuarioService usuarioService)
        {
            _loginService = loginService;
            _appSettings = appSettings.Value;
            _usuarioService = usuarioService;
        }

        public LoginResponse RealizarLogin(string dadosLogin)
        {
            var login = JsonConvert.DeserializeObject<LoginRequest>(dadosLogin);

            var password = CryptoEngine.EncryptPlainTextToCypher(login.Password, login.UserName);

            var loginDb = _loginService.ObterLogin(login.UserName);

            if(loginDb != null && loginDb.Password == password)
            {
                var token = generateJwtToken(loginDb);
                var tipoUsuario = _usuarioService.ObtemUsuario(u => u.Id == loginDb.IdUsuario).TipoUsuario;
                return new LoginResponse()
                {
                    Id = loginDb.IdUsuario.Value,
                    UserName = login.UserName,
                    Token = token,
                    TipoUsuario = tipoUsuario
                };
            }

            return null;
        }

        public LoginModel GetById(Guid id)
        {
            return _loginService.ObterPorId(id);
        }

        private string generateJwtToken(LoginModel loginDb)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", loginDb.IdUsuario.Value.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
