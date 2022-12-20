﻿using AHM.Total.Travel.BusinessLogic.Services;
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
    public class TransportsController : Controller
    {
        private readonly TransportService _transportService;
        private readonly IMapper _mapper;

        public TransportsController(TransportService transportService, IMapper mapper)
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
                var list = _transportService.ListTransports();
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
        [AllowAnonymous]
        [HttpGet("ListComplete")]
        public IActionResult ListComplete()
        {
            var list = _transportService.ListTransportsComplete();
            return Ok(list);
        }


        [HttpPost("Insert")]
        public IActionResult Insert(TransportesViewModel item)
        {
            try
            {
                var items = _mapper.Map<tbTransportes>(item);
                var result = _transportService.CreateTransports(items);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, TransportesViewModel items)
        {

            try
            {
                var item = _mapper.Map<tbTransportes>(items);
                var result = _transportService.UpdateTransports(id, item);
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
                var result = _transportService.DeleteTransports(id, Mod);
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
                var result = _transportService.FindTransports(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
    }
}
