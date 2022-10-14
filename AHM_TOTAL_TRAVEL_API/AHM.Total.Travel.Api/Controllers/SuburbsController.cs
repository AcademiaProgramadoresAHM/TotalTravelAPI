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
    [Authorize(Roles = "Administrador")]
    public class SuburbsController : Controller
    {

        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;
        public SuburbsController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _generalService.ListSuburbs();
            return Ok(list);
        }


        [HttpPost("Insert")]
        public IActionResult Insert(ColoniasViewModel coloniasViewModel)
        {
            var items = _mapper.Map<tbColonias>(coloniasViewModel);
            var result = _generalService.CreateSuburbs(items);
            return Ok(result);
        }


        [HttpPut("Update")]
        public IActionResult Update(int id, ColoniasViewModel items)
        {

            var item = _mapper.Map<tbColonias>(items);
            var result = _generalService.UpdateSuburbs(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _generalService.DeleteSuburbs(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

            var result = _generalService.FindSuburbs(Id);
            return Ok(result);
        }

    }
}
