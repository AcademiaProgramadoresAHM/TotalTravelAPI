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
    public class PartnerTypeController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public PartnerTypeController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _generalService.ListPartnersType();
            return Ok(list);

        }

        [HttpPost("Insert")]
        public IActionResult Insert(TiposPartnersViewModel tipoPartnersViewModel)
        {
            var items = _mapper.Map<tbTipoPartners>(tipoPartnersViewModel);
            var result = _generalService.CreatePartnersType(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, TiposPartnersViewModel tipoPartnersViewModel)
        {

            var item = _mapper.Map<tbTipoPartners>(tipoPartnersViewModel);
            var result = _generalService.UpdatePartnersType(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _generalService.DeletePartnersType(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            var result = _generalService.FindPartnersType(Id);
            return Ok(result);
        }
    }
}
