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
            try
            {
                var list = _AccessService.ListNavbarGroups();
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Insert")]
        public IActionResult Insert(NavbarViewModel item)
        {
            try
            {
                var items = _mapper.Map<tblGruposElementosNavbar>(item);
                var result = _AccessService.CreateNavbarGroups(items);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPut("Update")]
        public IActionResult Update(int id, NavbarViewModel items)
        {
            try
            {
                var item = _mapper.Map<tblGruposElementosNavbar>(items);
                var result = _AccessService.UpdateNavbarGroups(id, item);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            try
            {
                var result = _AccessService.DeleteNavbarGroups(id, Mod);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [AllowAnonymous]
        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            try
            {
                var result = _AccessService.FindNavbarGroups(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
