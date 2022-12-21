using AHM.Total.Travel.BusinessLogic;
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
            try
            {
                var list = _AccessService.ListRolePermission();
                return Ok(list);
            }
            catch (Exception)
            {

                ServiceResult serviceResult = new ServiceResult();
                return Ok(serviceResult.Error());
            }
            
        }

        [HttpPost("Insert")]
        public IActionResult Insert(RolesPermisosViewModel item)
        {
            try
            {
                var items = _mapper.Map<tbRolesPermisos>(item);
                var result = _AccessService.CreateRolePermission(items);
                return Ok(result);
            }
            catch (Exception)
            {


                ServiceResult serviceResult = new ServiceResult();
                return Ok(serviceResult.Error());
            }
           
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, RolesPermisosViewModel items)
        {
            try
            {
                var item = _mapper.Map<tbRolesPermisos>(items);
                var result = _AccessService.UpdateRolePermission(id, item);
                return Ok(result);
            }
            catch (Exception)
            {


                ServiceResult serviceResult = new ServiceResult();
                return Ok(serviceResult.Error());
            }
          

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            try
            {
                var result = _AccessService.DeleteRolePermission(id, Mod);
                return Ok(result);
            }
            catch (Exception)
            {


                ServiceResult serviceResult = new ServiceResult();
                return Ok(serviceResult.Error());
            }
           

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            try
            {
                var result = _AccessService.FindRolePermission(Id);
                return Ok(result);
            }
            catch (Exception)
            {


                ServiceResult serviceResult = new ServiceResult();
                return Ok(serviceResult.Error());
            }
           
        }
    }
}
