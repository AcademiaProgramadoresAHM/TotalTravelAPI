﻿using AHM.Total.Travel.BusinessLogic.Services;
using AHM.Total.Travel.Common.Models;
using AHM.Total.Travel.Entities.Entities;
using AutoMapper;
using ConciertosProyecto.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CiudadesController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;
        public CiudadesController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }


        [HttpGet("List")]
        public IActionResult List()
        {
                var list = _generalService.ListCities();
                return Ok(list);
            
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, CiudadesViewModel items)
        {

                var item = _mapper.Map<tbCiudades>(items);
                var result = _generalService.UpdateCity(id, item);
                return Ok(result);


            
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
                var result = _generalService.DeleteCity(id, Mod);
                return Ok(result);
            
        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

                var result = _generalService.FindCity(Id);
                return Ok(result);
        }


    }
}
