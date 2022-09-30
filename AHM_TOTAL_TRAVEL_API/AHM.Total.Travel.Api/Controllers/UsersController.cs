using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public UsersController(AccessService accessService, IMapper mapper)
        {
            _accessService = accessService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _accessService.ListUsers();
            return Ok(list);
        }
        [AllowAnonymous]
        [HttpPost("Insert")]
        public IActionResult Insert(UsuariosViewModel item)
        {
            var items = _mapper.Map<tbUsuarios>(item);
            var result = _accessService.CreateUsers(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, UsuariosViewModel items)
        {
            var item = _mapper.Map<tbUsuarios>(items);
            var result = _accessService.UpdateUsers(id, item);
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
