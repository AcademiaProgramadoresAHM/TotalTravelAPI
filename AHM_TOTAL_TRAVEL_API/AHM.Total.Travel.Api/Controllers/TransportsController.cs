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
    [Route("API/[controller]")]
    public class TransportsController : Controller
    {
        private readonly TransportService _transportService;
        private readonly IMapper _mapper;

        public TransportsController(TransportService transportService, IMapper mapper)
        {
            _transportService = transportService;
            _mapper = mapper;
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _transportService.ListTransports();
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(TransportesViewModel item)
        {
            var items = _mapper.Map<tbTransportes>(item);
            var result = _transportService.CreateTransports(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, TransportesViewModel items)
        {

            var item = _mapper.Map<tbTransportes>(items);
            var result = _transportService.UpdateTransports(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _transportService.DeleteTransports(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            var result = _transportService.FindTransports(Id);
            return Ok(result);
        }
    }
}
