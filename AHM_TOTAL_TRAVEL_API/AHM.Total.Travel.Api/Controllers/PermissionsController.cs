using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using ConciertosProyecto.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController]
    [Route("API/[Controller]")]
    [Authorize(Roles = "Administrador")]
    [AllowAnonymous]
    public class PermissionsController : Controller
    {
        private readonly AccessService _AccessService;
        private readonly IMapper _mapper;
        public PermissionsController(AccessService AccessService, IMapper mapper)
        {
            _AccessService = AccessService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        [AllowAnonymous]
        public IActionResult List()
        {
            var list = _AccessService.ListPermission();
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(PermisosViewModel item)
        {
            var items = _mapper.Map<tbPermisos>(item);
            var result = _AccessService.CreatePermission(items);
            return Ok(result);
        }


            [HttpPut("Update")]
        public IActionResult Update(int id, PermisosViewModel items)
        {

            var item = _mapper.Map<tbPermisos>(items);
            var result = _AccessService.UpdatePermission(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _AccessService.DeletePermission(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

            var result = _AccessService.FindPermission(Id);
            return Ok(result);
        }
    }
}

