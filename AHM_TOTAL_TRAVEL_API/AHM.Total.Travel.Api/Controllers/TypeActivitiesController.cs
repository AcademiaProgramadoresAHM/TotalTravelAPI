using AHM.Total.Travel.BusinessLogic.Services;
using AutoMapper;
using AHM.Total.Travel.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AHM.Total.Travel.Entities.Entities;

namespace AHM.Total.Travel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeActivitiesController : ControllerBase
    {


        private readonly ActivitiesService _activitiesService;
        private readonly IMapper _mapper;

        public TypeActivitiesController(ActivitiesService activitiesService, IMapper mapper)
        {
            _activitiesService = activitiesService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _activitiesService.ListActTyp();
            return Ok(list);

        }

        [HttpPost("Insert")]
        public IActionResult Insert(TiposActividadesViewModel item)
        {
            var items = _mapper.Map<tbTiposActividades>(item);
            var result = _activitiesService.CreateActTyp(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, TiposActividadesViewModel items)
        {

            var item = _mapper.Map<tbTiposActividades>(items);
            var result = _activitiesService.UpdateActTyp(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _activitiesService.DeleteActTyp(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {

            var result = _activitiesService.FindActTyp(Id);
            return Ok(result);
        }
    }

}
