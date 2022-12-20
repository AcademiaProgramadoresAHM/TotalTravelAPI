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
    [Authorize(Roles = "Administrador, Moderador de Transporte")]
    public class TypesTransportController : Controller
    {
        private readonly TransportService _transportService;
        private readonly IMapper _mapper;
        public TypesTransportController(TransportService transportService, IMapper mapper)
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
                var list = _transportService.ListTipoTransports();
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            

        }
        [HttpPost("Insert")]
        public IActionResult Insert(TiposTransportesViewModel item)
        {
            try
            {
                var items = _mapper.Map<tbTiposTransportes>(item);
                var result = _transportService.CreateTipoTransports(items);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
        [HttpPut("Update")]
        public IActionResult Update(int id, TiposTransportesViewModel items)
        {

            try
            {
                var item = _mapper.Map<tbTiposTransportes>(items);
                var result = _transportService.UpdateTipoTransports(id, item);
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
                var result = _transportService.DeleteTipoTransports(id, Mod);
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
                var result = _transportService.FindTipoTransports(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
    }
}
