using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.DataAccess.Repositories;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    [Authorize(Roles = "Administrador, Moderador de Actividades")]
    public class UsersController : Controller
    {
        private readonly AccessService _accessService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _IWebHostEnvironment;
        private readonly ImagesService _imagesService;
        

        public UsersController(AccessService accessService, IMapper mapper, IWebHostEnvironment iWebHostEnvironment, ImagesService imagesService)
        {
            _accessService = accessService;
            _mapper = mapper;
            _IWebHostEnvironment = iWebHostEnvironment;
            _imagesService = imagesService;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _accessService.ListUsers();
            return Ok(list);
        }

        [AllowAnonymous]
        [HttpPost("Insert")]
        public IActionResult Insert([FromForm] UsuariosInsertViewModel item)
        {
            var user = _mapper.Map<tbUsuarios>(item);
            var result = _accessService.CreateUsers(user, item.File);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPut("Update")]
        public IActionResult Update(int id, [FromForm] UsuariosUpdateViewModel items)
        {
            var item = _mapper.Map<tbUsuarios>(items);
            var result = _accessService.UpdateUsers(id, item, items.Usua_Url);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPut("UpdatePassword")]
        public IActionResult changePassword(UsuariosPasswordViewModel items)
        {
            var item = _mapper.Map<tbUsuarios>(items);
            var result = _accessService.UpdatePassword(item);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int mod)
        {
            var result = _accessService.DeleteUsers(id, mod);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("Find")]
        public IActionResult Details(int id)
        {
            var result = _accessService.FindUsers(id);
            return Ok(result);
        }

    }
}
