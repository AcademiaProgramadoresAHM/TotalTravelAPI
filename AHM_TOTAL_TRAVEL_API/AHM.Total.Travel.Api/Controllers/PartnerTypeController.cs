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
            try
            {
                var list = _generalService.ListPartnersType();
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost("Insert")]
        public IActionResult Insert(TiposPartnersViewModel tipoPartnersViewModel)
        {
            try
            {
                var items = _mapper.Map<tbTipoPartners>(tipoPartnersViewModel);
                var result = _generalService.CreatePartnersType(items);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, TiposPartnersViewModel tipoPartnersViewModel)
        {
            try
            {
                var item = _mapper.Map<tbTipoPartners>(tipoPartnersViewModel);
                var result = _generalService.UpdatePartnersType(id, item);
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
                var result = _generalService.DeletePartnersType(id, Mod);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            try
            {
                var result = _generalService.FindPartnersType(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
