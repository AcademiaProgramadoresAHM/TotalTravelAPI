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
    public class RoomsPackagesController : Controller
    {
        private readonly SaleService _saleService;
        private readonly IMapper _mapper;

        public RoomsPackagesController(SaleService saleService, IMapper mapper)
        {
            _saleService = saleService;
            _mapper = mapper;
        }

        
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _saleService.ListPackageRooms();
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(PaquetesHabitacionesViewModel item)
        {
            var items = _mapper.Map<tbPaquetesHabitaciones>(item);
            var result = _saleService.CreatePackageRooms(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, PaquetesHabitacionesViewModel items )
        {
            var item = _mapper.Map<tbPaquetesHabitaciones>(items);
            var result = _saleService.UpdatePackageRooms(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _saleService.DeletePackageRooms(id, Mod);
            return Ok(result);
        }

        [HttpGet("Find")]
        public IActionResult Find(int id)
        {
            var item = _saleService.FindPackagesRooms(id);
            return Ok(item);
        }
    }
}
