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
    public class RolePermissionsController : Controller
    {

        private readonly AccessService _AccessService;
        private readonly IMapper _mapper;
        public RolePermissionsController(AccessService AccessService, IMapper mapper)
        {
            _AccessService = AccessService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _AccessService.ListRolePermission();
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(RolesPermisosViewModel item)
        {
            var items = _mapper.Map<tbRolesPermisos>(item);
            var result = _AccessService.CreateRolePermission(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, RolesPermisosViewModel items)
        {

            var item = _mapper.Map<tbRolesPermisos>(items);
            var result = _AccessService.UpdateRolePermission(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _AccessService.DeleteRolePermission(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

            var result = _AccessService.FindRolePermission(Id);
            return Ok(result);
        }
    }
}
