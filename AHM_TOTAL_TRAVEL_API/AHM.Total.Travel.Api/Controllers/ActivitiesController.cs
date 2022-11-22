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
    [Authorize(Roles = "Administrador, Moderador de Actividades, Moderador de Hotel")]
    public class ActivitiesController : Controller
    {
        private readonly ActivitiesService _activitiesService;
        private readonly IMapper _mapper;

        public ActivitiesController(ActivitiesService activitiesService, IMapper mapper)
        {
            _activitiesService = activitiesService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _activitiesService.ListActivities();
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(ActividadesViewModel Actividades)
        {
            var item = _mapper.Map<tbActividades>(Actividades);
            var response = _activitiesService.CreateActivity(item);
            return Ok(response);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, ActividadesViewModel actividadesViewModel)
        {
            var item = _mapper.Map<tbActividades>(actividadesViewModel);
            var result = _activitiesService.UpdateActivity(id, item);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int mod)
        {
            var result = _activitiesService.DeleteActivity(id, mod);
            return Ok(result);
        }

        [HttpGet("Find")]
        public IActionResult Details(int id)
        {
            var result = _activitiesService.FindActivity(id);
            return Ok(result);
        }
        
    }
}
