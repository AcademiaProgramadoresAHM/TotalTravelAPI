using AHM.Total.Travel.BusinessLogic.Services;
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
    public class ActivitiesExtraController : Controller
    {
        private readonly ActivitiesService _activitiesService;
        private readonly IMapper _mapper;
        public ActivitiesExtraController(ActivitiesService activitiesService, IMapper mapper)
        {
            _activitiesService = activitiesService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _activitiesService.ListActiExt();
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(ActividadesExtrasViewModel ActividadesExtras)
        {
            var item = _mapper.Map<tbActividadesExtras>(ActividadesExtras);
            var response = _activitiesService.CreateActiExt(item);
            return Ok(response);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, ActividadesExtrasViewModel items)
        {
            var item = _mapper.Map<tbActividadesExtras>(items);
            var result = _activitiesService.UpdateActiExt(id, item);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int mod)
        {
            var result = _activitiesService.DeleteActiExt(id, mod);
            return Ok(result);
        }

        [HttpGet("Find")]
        public IActionResult Details(int id)
        {
            var result = _activitiesService.FindActiExt(id);
            return Ok(result);
        }
    }
}
