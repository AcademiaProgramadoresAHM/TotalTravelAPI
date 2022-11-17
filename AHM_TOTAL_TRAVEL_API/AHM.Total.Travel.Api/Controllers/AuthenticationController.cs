using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using AHM.Total.Travel.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using static AHM.Total.Travel.Api.Controllers.LoginController;
using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.SecurityModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.BusinessLogic;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;

namespace AHM.Total.Travel.Api.Controllers
{
    [Route("API/[controller]")]
    [ApiController]

    public class AuthenticationController : ControllerBase
    {
        private readonly LoginService _loginService;
        private readonly AccessService _accessService;

        public AuthenticationController(LoginService loginService, AccessService accessService)
        {
            _loginService = loginService;
            _accessService = accessService;
        }

        [HttpGet("Private")]
        [Authorize]
        public IActionResult Private()
        {
            //extract jwt token from request
            //var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            VW_tbUsuarios userClaims = _loginService.getClaims(HttpContext);

            return Ok($"Hola {userClaims.Nombre + " " + userClaims.Apellido}, este endpoint es privado y tu eres un {userClaims.Rol} \n" +
                $"Tu email es: {userClaims.Email} y tu id es: {userClaims.ID} \n");
        }



        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hola, este endpoint es publico");
        }

        [HttpGet("Logout")]
        public ServiceResult Logout()
        {
            string clientRefreshToken = Request.Cookies["refresh-token"];
            ServiceResult result = _accessService.AuthenticateTokenExistence(clientRefreshToken);


            if (string.IsNullOrEmpty(clientRefreshToken) || result.Code == 400)
            {
                return new ServiceResult().BadRequest("No se ha enviado ningún tipo de credenciales");
            }

            if (result.Code == 200)
            {
                VW_tbUsuariosLogins usuariosLogins = result.Data;
                RefreshToken refreshToken = _loginService.FromViewToModel(result.Data);
                refreshToken.Revoked = DateTime.Now;
                ServiceResult response = _accessService.UpdateLogin(refreshToken.ID, _loginService.FromModelToEntity(refreshToken));
                if (response.Code == 200)
                {
                    HttpContext.Response.Cookies.Delete("refresh-token");
                    return new ServiceResult().Ok(data: "Sesión cerrada correctamente");
                }
                else
                {
                    return new ServiceResult().BadRequest("Occurió un error al cerrar la sesión");
                }
            }
            HttpContext.Response.Cookies.Delete("refresh-token");
            return new ServiceResult().Ok(data: "La sesión se ha cerrado correctamente");
        }


        [AllowAnonymous]
        [HttpPost("Refresh-token")]
        public IActionResult RefreshToken(RefreshAccessToken token)
        {

            string refreshToken = HttpContext.Request.Cookies["refresh-token"];
            ServiceResult result = _accessService.AuthenticateTokenExistence(refreshToken);
            VW_tbUsuariosLogins UserLogins = result.Data;

            if (result.Code == 400 || string.IsNullOrEmpty(refreshToken)||result.Code==501) 
            {
                return Unauthorized("Los datos de la sesión son incorrectos, inicie sesión nuevamente");
            }

            if (UserLogins.isActive.Value)
            {
                VW_tbUsuarios user = _accessService.FindUsers(UserLogins.Usua_ID.Value).Data;
                if (user != null)
                {
                    return Ok(_loginService.GenerateJWT(user));
                }
                return NotFound("No se pudo encontrar el usuario");
            }
            else
            {
                return Unauthorized("Sesion caducada, inicie sesión nuevamente");
            }
            
        }
    }
}
