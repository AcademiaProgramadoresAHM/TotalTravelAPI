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

namespace AHM.Total.Travel.Api.Controllers
{
    [Route("API/[controller]")]
    [ApiController]

    public class AuthenticationController : ControllerBase
    {
        [HttpGet("Private")]
        [Authorize(Roles ="Administrador, Cliente")]
        public IActionResult Private()
        {
            var user = getCurrentUser();
            return Ok($"Hola {user.nombre_completo}, este endpoint es privado y tu eres un {user.Rol}, version modificada de la API");
        }

        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hola, este endpoint es publico");
        }

        private VW_tbUsuarios getCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new VW_tbUsuarios
                {
                    nombre_completo = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    Rol = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
