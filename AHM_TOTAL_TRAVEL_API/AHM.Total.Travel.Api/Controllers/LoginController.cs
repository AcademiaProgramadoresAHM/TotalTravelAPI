using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Entities.Entities;
using AHM.Total.Travel.Common.SecurityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ConciertosProyecto.BusinessLogic;
using AutoMapper;
using AHM.Total.Travel.Common.Models;

namespace AHM.Total.Travel.Api.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AccessService _accessService;
        private readonly EmailSenderService _emailSenderService;
        private readonly IMapper _mapper;
        public LoginController(IConfiguration config,EmailSenderService emailSenderService, AccessService accessService, IMapper mapper)
        {
            _config = config;
            _accessService = accessService;
            _emailSenderService = emailSenderService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public ServiceResult Login([FromBody] UserLoginModel userLoginModel)
        {
            ServiceResult result = new ServiceResult();

            var user = Authenticate(userLoginModel);
            if (user != null)
            {
                var response = _mapper.Map<UserLoggedModel>(user);
                response.Token = GenerateJWT(user);
                return result.Ok(data:response);
            }
            return result.NotAcceptable("El usuario no fue encontrado");
        }

        [AllowAnonymous]
        [HttpPost("EmailSender")]
        public ServiceResult EmailSender(EmailDataViewModel EmailDataViewModel)
        {
            ServiceResult result = new ServiceResult();

            var user = _emailSenderService.RetrievePassword(EmailDataViewModel);
            return user;
        }

        private VW_tbUsuarios Authenticate(UserLoginModel userLoginModel)
        {
            var user = _accessService.ApiLogin(userLoginModel);
            
            if (user.Data != null)
            { 
                return user.Data;
            }
            return null;
        }

        private string GenerateJWT(VW_tbUsuarios user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.nombre_completo),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Rol),
                new Claim("UsuarioID",user.ID.ToString()),
                new Claim("RolID",user.Role_ID.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires:DateTime.Now.AddDays(15),
                signingCredentials:credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
