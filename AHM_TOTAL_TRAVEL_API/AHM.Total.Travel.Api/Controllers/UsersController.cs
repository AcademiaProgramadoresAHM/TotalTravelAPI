using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    [Authorize(Roles = "Administrador")]
    public class UsersController : Controller
    {
        private readonly AccessService _accessService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _IWebHostEnvironment;
        public UsersController(AccessService accessService, IMapper mapper, IWebHostEnvironment IWebHostEnvironment)
        {
            _IWebHostEnvironment = IWebHostEnvironment;
            _accessService = accessService;
            _mapper = mapper;
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
        public IActionResult Insert([FromForm] UsuariosViewModel item)
        {
            IFormFile file;
            if (item.File != null)
            {
                file = item.File;
            }
            else
            {
                string pathdefault = Path.GetFullPath("ImagesAPI/Assets_System_Photos/ImageDefault.jpg");
                byte[] byteFile = System.IO.File.ReadAllBytes(pathdefault);

                var stream = new MemoryStream(byteFile);
                file = new FormFile(stream, 0, stream.Length, "ImageDefault", "ImageDefault.jpg");
            }
            var items = _mapper.Map<tbUsuarios>(item);
            var result = _accessService.CreateUsers(items, file);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, UsuariosViewModel items)
        {
            var item = _mapper.Map<tbUsuarios>(items);
            var result = _accessService.UpdateUsers(id, item);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPut("UpdatePassword")]
        public IActionResult changePassword(UsuariosViewModel items)
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

        [HttpGet("Find")]
        public IActionResult Details(int id)
        {
            var result = _accessService.FindUsers(id);
            return Ok(result);
        }

    }
}
