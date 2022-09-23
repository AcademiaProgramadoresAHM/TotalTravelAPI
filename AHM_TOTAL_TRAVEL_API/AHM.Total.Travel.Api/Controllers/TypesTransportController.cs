using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypesTransportController : Controller
    {
        private readonly TransportService _transportService;
        private readonly IMapper _mapper;
        public TypesTransportController(TransportService transportService, IMapper mapper)
        {
            _transportService = transportService;
            _mapper = mapper;
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _transportService.ListTipoTransports();
            return Ok(list);

        }
        [HttpPost("Insert")]
        public IActionResult Insert(TiposTransportesViewModel item)
        {
            var items = _mapper.Map<tbTiposTransportes>(item);
            var result = _transportService.CreateTipoTransports(items);
            return Ok(result);
        }
        [HttpPut("Update")]
        public IActionResult Update(int id, TiposTransportesViewModel items)
        {

            var item = _mapper.Map<tbTiposTransportes>(items);
            var result = _transportService.UpdateTipoTransports(id, item);
            return Ok(result);

        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _transportService.DeleteTipoTransports(id, Mod);
            return Ok(result);

        }
        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            var result = _transportService.FindTipoTransports(Id);
            return Ok(result);
        }
    }
}
