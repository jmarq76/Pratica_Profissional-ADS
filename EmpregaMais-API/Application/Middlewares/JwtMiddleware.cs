using Application.Helper;
using Application.Interfaces;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Application.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        private readonly IScopeContext _scopeContext;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings, IScopeContext scopeContext)
        {
            _next = next;
            _appSettings = appSettings.Value;
            _scopeContext = scopeContext;
        }

        public async Task Invoke(HttpContext context, ILogin loginService, IUsuarioService usuarioService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if(token != null)
            {
                attachUserContext(context, loginService, usuarioService, token);
            }

            await _next(context);
        }

        private void attachUserContext(HttpContext context, ILogin loginService, IUsuarioService usuarioService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                _scopeContext.Id = userId;
                _scopeContext.IdPerfil = usuarioService.ObtemUsuario(u => u.Id == userId).IdPerfil.Value;

                context.Items["User"] = loginService.GetById(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
