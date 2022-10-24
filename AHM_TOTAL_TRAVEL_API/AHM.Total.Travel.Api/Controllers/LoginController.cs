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
using AutoMapper;
using AHM.Total.Travel.Common.Models;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using AHM.Total.Travel.DataAccess;
using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.BusinessLogic;
using static AHM.Total.Travel.BusinessLogic.Services.ImagesService;

namespace AHM.Total.Travel.Api.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly EmailSenderService _emailSenderService;
        private readonly IMapper _mapper;
        private readonly LoginService _loginService;
        private readonly ImagesService _imagesService;

        public LoginController(EmailSenderService emailSenderService, IMapper mapper, LoginService loginService, ImagesService imagesService)
        {
            _emailSenderService = emailSenderService;
            _mapper = mapper;
            _loginService = loginService;
            _imagesService = imagesService;
        }

        [AllowAnonymous]
        [HttpPost]
        public ServiceResult Login([FromBody] UserLoginModel userLoginModel)
        {
            ServiceResult result = new ServiceResult();

            VW_tbUsuarios user = _loginService.Authenticate(userLoginModel);
            if (user != null)
            {
                UserLoggedModel response = _mapper.Map<UserLoggedModel>(user);
                response.Token = _loginService.GenerateJWT(user);
                response.Image_URL = ((ImagesDetails)_imagesService.getImagesFilesByRoute(user.Image_URL).Data).ImageUrl;
                var refreshToken = _loginService.setTokenCookie(response, HttpContext);

                return result.Ok(data: response);
            }
            return result.NotAcceptable("El usuario no fue encontrado");
        }

        
        [AllowAnonymous]
        [HttpPost("EmailVerification")]
        public ServiceResult EmailVerification(EmailDataViewModel emailDataViewModel)
        {
            string email = emailDataViewModel.To;
            var result = new ServiceResult();
            try
            {
                var map = _emailSenderService.EmailVerification(email);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("EmailSender")]
        public ServiceResult EmailSender(EmailDataViewModel EmailDataViewModel)
        {
            ServiceResult result = new ServiceResult();

            var user = _emailSenderService.RetrievePassword(EmailDataViewModel);
            return user;
        }

        [AllowAnonymous]
        [HttpPost("EmailContact")]
        public ServiceResult EmailContact(EmailDataViewModel EmailDataViewModel, string body)
        {
            ServiceResult result = new ServiceResult();

            var user = _emailSenderService.ContactEmail(EmailDataViewModel, body);
            return user;
        }
    }
}
