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
    public class HorariosTransportesController : Controller
    {
        private readonly TransportService _transportService;
        private readonly IMapper _mapper;
        public HorariosTransportesController(TransportService transportService, IMapper mapper)
        {
            _transportService = transportService;
            _mapper = mapper;
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _transportService.ListHorariosTransports();
            return Ok(list);

        }
        [HttpPut("Update")]
        public IActionResult Update(int id, HorariosTransportesViewModel items)
        {

            var item = _mapper.Map<tbHorariosTransportes>(items);
            var result = _transportService.UpdateHorariosTransports(id, item);
            return Ok(result);

        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _transportService.DeleteHorariosTransports(id, Mod);
            return Ok(result);

        }
        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            var result = _transportService.FindHorariosTransports(Id);
            return Ok(result);
        }
    }
}
