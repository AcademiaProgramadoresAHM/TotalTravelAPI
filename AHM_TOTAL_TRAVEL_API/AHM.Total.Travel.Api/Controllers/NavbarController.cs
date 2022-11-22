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
    [Route("API/[Controller]")]
    [Authorize(Roles = "Administrador")]
    public class NavbarController : Controller
    {
        private readonly AccessService _AccessService;
        private readonly IMapper _mapper;
        public NavbarController(AccessService AccessService, IMapper mapper)
        {
            _AccessService = AccessService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _AccessService.ListNavbarGroups();
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(NavbarViewModel item)
        {
            var items = _mapper.Map<tblGruposElementosNavbar>(item);
            var result = _AccessService.CreateNavbarGroups(items);
            return Ok(result);
        }


        [HttpPut("Update")]
        public IActionResult Update(int id, NavbarViewModel items)
        {

            var item = _mapper.Map<tblGruposElementosNavbar>(items);
            var result = _AccessService.UpdateNavbarGroups(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _AccessService.DeleteNavbarGroups(id, Mod);
            return Ok(result);

        }

        [AllowAnonymous]
        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

            var result = _AccessService.FindNavbarGroups(Id);
            return Ok(result);
        }
    }
}
