using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{

    [ApiController]
    [Route("API/[controller]")]
    [Authorize(Roles = "Administrador, Cliente, Moderador de Transporte")]
    public class DestinationsTransportationsController : Controller
    {
        private readonly TransportService _transportService;
        private readonly IMapper _mapper;

        public DestinationsTransportationsController(TransportService transportService, IMapper mapper)
        {
            _transportService = transportService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
            var list = _transportService.ListDestinosTransports();
            return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }

        [HttpPost("Insert")]
        public IActionResult Insert(DestinosTransporteViewModel destinosTransporteViewModel)
        {
            try
            {
                var items = _mapper.Map<tbDestinosTransportes>(destinosTransporteViewModel);
                var result = _transportService.CreateDestinosTransports(items);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, DestinosTransporteViewModel destinosTransporteViewModel)
        {
            try
            {
                var item = _mapper.Map<tbDestinosTransportes>(destinosTransporteViewModel);
                var result = _transportService.UpdateDestinosTransports(id, item);
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
                var result = _transportService.DeleteDestinosTransports(id, Mod);
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
                var result = _transportService.FindDestinosTransports(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
