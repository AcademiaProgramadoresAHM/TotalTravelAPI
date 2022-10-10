using AHM.Total.Travel.Common.SecurityModels;
using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using AHM.Total.Travel.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Security.Cryptography;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class LoginService
    {

        private readonly UsuariosRepository _usuariosRepository;
        private readonly UsuariosLoginsRepository _usuariosLoginsRepository;
        private readonly IConfiguration _config;
        public static RefreshToken _refreshToken = new RefreshToken();

        public LoginService(UsuariosRepository usuariosRepository, UsuariosLoginsRepository usuariosLoginsRepository, IConfiguration config)
        {
            _usuariosRepository = usuariosRepository;
            _usuariosLoginsRepository = usuariosLoginsRepository;
            _config = config;
        }



        //Verifica la existencia del usuario

        public VW_tbUsuarios Authenticate(UserLoginModel userLoginModel)
        {
            var user = ApiLogin(userLoginModel);

            if (user.Data != null)
            {
                return user.Data;
            }            
            return null;
        }

        //Buscar por email
        public ServiceResult ApiLogin(UserLoginModel userLogin)
        {
            var result = new ServiceResult();
            try
            {
                var user = _usuariosRepository.AuthenticateUser(userLogin.Email, userLogin.Password);
                if (user != null)
                {
                    return result.Ok(user);
                }
                return result.NotFound("No se pudo encontrar el usuario");

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        //Genera el JWT token
        public string GenerateJWT(VW_tbUsuarios user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, $"{user.Nombre} {user.Apellido}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Rol),
                new Claim("UsuarioID",user.ID.ToString()),
                new Claim("RolID",user.Role_ID.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );            

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //Asigna una cookie al cliente de tipo HttpOnly=true que contiene un "refresh-token"
        public string setTokenCookie(UserLoggedModel user, HttpContext httpContext)
        {
            string clientRefreshToken = httpContext.Request.Cookies["refresh-token"];

            VW_tbUsuariosLogins UserLogin = _usuariosLoginsRepository.FindByToken(clientRefreshToken);
            
            if (string.IsNullOrEmpty(clientRefreshToken))
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(7)
                };

                var Token = Guid.NewGuid().ToString();

                RefreshToken refreshToken = new RefreshToken
                {
                    Usua_ID = user.ID,
                    Token = Token,
                    Expires = DateTime.Parse(cookieOptions.Expires.ToString()),
                    Created = DateTime.UtcNow
                };
                tbUsuariosLogins usuariosLogins = FromModelToEntity(refreshToken);
                try
                {
                    var response = _usuariosLoginsRepository.Insert(usuariosLogins);
                }
                catch (Exception e)
                {

                    throw e;
                }

                httpContext.Response.Cookies.Append("refresh-token", refreshToken.Token, cookieOptions);
                return refreshToken.Token;
            }

            return null;

        }

        //Extrae datos de los Claims del payload del JWT
        public VW_tbUsuarios getClaims(HttpContext context)
        {

            IEnumerable<Claim> claims = context.User.Claims;
            if (claims != null)
            {
                
                VW_tbUsuarios Usuario = new VW_tbUsuarios {
                    ID = int.Parse( claims.FirstOrDefault(x => x.Type == "UsuarioID")?.Value),
                    Nombre = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    Rol = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value,
                    Role_ID = int.Parse(claims.FirstOrDefault(x => x.Type == "RolID")?.Value)
                };
                return Usuario;
            }
            return null;
        }
        public tbUsuariosLogins FromModelToEntity(RefreshToken refreshToken)
        {
            tbUsuariosLogins usuariosLogins = new tbUsuariosLogins
            {
                Usua_ID = refreshToken.Usua_ID,
                RefreshToken = refreshToken.Token,
                Expires = refreshToken.Expires,
                Created = refreshToken.Created,
                Revoked = refreshToken.Revoked,
                isActive = refreshToken.isActive
            };
            return usuariosLogins;
        }

        public RefreshToken FromViewToModel(VW_tbUsuariosLogins usuariosLogins)
        {
            RefreshToken refreshToken = new RefreshToken
            {
                ID = usuariosLogins.ID,
                Usua_ID = usuariosLogins.Usua_ID,
                Token = usuariosLogins.RefreshToken,
                Expires = usuariosLogins.Expires.Value,
                Created = usuariosLogins.Created.Value,
                Revoked = usuariosLogins.Revoked
            };
            return refreshToken;
        }
    }

}
