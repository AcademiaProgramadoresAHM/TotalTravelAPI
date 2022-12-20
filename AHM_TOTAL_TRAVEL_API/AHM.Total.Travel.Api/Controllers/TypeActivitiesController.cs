using AHM.Total.Travel.BusinessLogic.Services;
using AutoMapper;
using AHM.Total.Travel.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AHM.Total.Travel.Entities.Entities;
using Microsoft.AspNetCore.Authorization;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    [Authorize(Roles = "Administrador, Moderador de Actividades")]
    public class TypeActivitiesController : ControllerBase
    {


        private readonly ActivitiesService _activitiesService;
        private readonly IMapper _mapper;

        public TypeActivitiesController(ActivitiesService activitiesService, IMapper mapper)
        {
            _activitiesService = activitiesService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                var list = _activitiesService.ListActTyp();
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            

        }

        [HttpPost("Insert")]
        public IActionResult Insert(TiposActividadesViewModel item)
        {
            try
            {
                var items = _mapper.Map<tbTiposActividades>(item);
                var result = _activitiesService.CreateActTyp(items);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, TiposActividadesViewModel items)
        {

            try
            {
                var item = _mapper.Map<tbTiposActividades>(items);
                var result = _activitiesService.UpdateActTyp(id, item);
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
                var result = _activitiesService.DeleteActTyp(id, Mod);
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
                var result = _activitiesService.FindActTyp(Id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
    }

}
