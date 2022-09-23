using AHM.Total.Travel.BusinessLogic.Services;
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

        [HttpPut("Update")]
        public IActionResult Update(int id, ActivitiesService items)
        {
            var item = _mapper.Map<tbActividades>(items);
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
