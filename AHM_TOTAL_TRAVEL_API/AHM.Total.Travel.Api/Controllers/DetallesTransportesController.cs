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
    [Route("[controller]")]
    public class DetallesTransportesController : Controller
    {
        private readonly TransportService _transportService;
        private readonly IMapper _mapper;

        public DetallesTransportesController(TransportService transportService, IMapper mapper)
        {
            _transportService = transportService;
            _mapper = mapper;
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _transportService.ListDetallesTransports();
            return Ok(list);


        }
        [HttpPut("Update")]
        public IActionResult Update(int id, DetallesTransportesViewModel items)
        {

            var item = _mapper.Map<tbDetallesTransportes>(items);
            var result = _transportService.UpdateDetallesTransports(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _transportService.DeleteDetallesTransports(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            var result = _transportService.FindDetallesTransports(Id);
            return Ok(result);
        }

    }
}
