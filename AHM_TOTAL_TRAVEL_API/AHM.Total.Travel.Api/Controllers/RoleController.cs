using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using ConciertosProyecto.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController] 
    [Route("[Controller]")]
    public class RoleController : Controller
        {
        private readonly AccessService _AccessService;
        private readonly IMapper _mapper;
        public RoleController(AccessService AccessService, IMapper mapper)
        {
            _AccessService = AccessService;
            _mapper = mapper;
        }


        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _AccessService.ListRole();
            return Ok(list);
        }

        [HttpPut("Update")]
            public IActionResult Update(int id, RolesViewModel items)
            {

                var item = _mapper.Map<tbRoles>(items);
                var result = _AccessService.UpdateRole(id, item);
                return Ok(result);

            }

            [HttpDelete("Delete")]
            public IActionResult Delete(int id, int Mod)
            {
                var result = _AccessService.DeleteRole(id, Mod);
                return Ok(result);

            }

            [HttpGet("Find")]
            public IActionResult Details(int Id)
            {

                var result = _AccessService.FindRole(Id);
                return Ok(result);
            }
    }
    }

