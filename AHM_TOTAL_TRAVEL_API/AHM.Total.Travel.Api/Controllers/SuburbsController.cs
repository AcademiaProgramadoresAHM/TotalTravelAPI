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
    [Authorize(Roles = "Administrador, Cliente, Moderador de Actividades")]
    public class SuburbsController : Controller
    {

        private  GeneralService _generalService;
        private static IMapper _mapper;
        public SuburbsController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                var list = _generalService.ListSuburbs();
                return Ok(list);
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
        }


        [HttpPost("Insert")]
        public IActionResult Insert(ColoniasViewModel coloniasViewModel)
        {
            try
            {
                var items = _mapper.Map<tbColonias>(coloniasViewModel);
                var result = _generalService.CreateSuburbs(items);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }


        [HttpPut("Update")]
        public IActionResult Update(int id, ColoniasViewModel items)
        {

            try
            {
                var item = _mapper.Map<tbColonias>(items);
                var result = _generalService.UpdateSuburbs(id, item);
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
                var result = _generalService.DeleteSuburbs(id, Mod);
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
                var result = _generalService.FindSuburbs(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

    }
}
