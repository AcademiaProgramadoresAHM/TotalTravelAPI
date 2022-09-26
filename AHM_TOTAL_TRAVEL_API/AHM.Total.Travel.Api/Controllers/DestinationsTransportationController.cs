﻿using AHM.Total.Travel.BusinessLogic.Services;
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
    public class DestinationsTransportationController : Controller
    {
        private readonly TransportService _transportService;
        private readonly IMapper _mapper;

        public DestinationsTransportationController(TransportService transportService, IMapper mapper)
        {
            _transportService = transportService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _transportService.ListDestinosTransports();
            return Ok(list);

        }

        [HttpPost("Insert")]
        public IActionResult Insert(DestinosTransporteViewModel destinosTransporteViewModel)
        {
            var items = _mapper.Map<tbDestinosTransportes>(destinosTransporteViewModel);
            var result = _transportService.CreateDestinosTransports(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, DestinosTransporteViewModel destinosTransporteViewModel)
        {

            var item = _mapper.Map<tbDestinosTransportes>(destinosTransporteViewModel);
            var result = _transportService.UpdateDestinosTransports(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _transportService.DeleteDestinosTransports(id, Mod);
            return Ok(result);
        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            var result = _transportService.FindDestinosTransports(Id);
            return Ok(result);
        }

    }
}
