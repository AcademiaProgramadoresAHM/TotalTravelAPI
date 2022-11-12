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
    [AllowAnonymous]
    public class AddressController : ControllerBase
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;
        public AddressController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        //[Authorize(Roles = "Cliente")]
        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _generalService.ListAddress();
            return Ok(list);
        }
        [AllowAnonymous]
        [HttpPost("Insert")]
        public IActionResult Insert(DireccionesViewModel direccionesViewModel)
        {
            var items = _mapper.Map<tbDirecciones>(direccionesViewModel);
            var result = _generalService.CreateAddress(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, DireccionesViewModel direccionesViewModel)
        {

            var item = _mapper.Map<tbDirecciones>(direccionesViewModel);
            var result = _generalService.UpdateAddress(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _generalService.DeleteAddress(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

            var result = _generalService.FindAddress(Id);
            return Ok(result);
        }
    }
}
