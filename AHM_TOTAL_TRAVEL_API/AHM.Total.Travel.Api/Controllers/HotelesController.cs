using AHM.Total.Travel.BusinessLogic.Services;
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
    public class HotelesController : Controller
    {
        private readonly HotelService _hotelService;
        private readonly IMapper _mapper;
        public HotelesController(HotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }


        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _hotelService.ListHotel();
            return Ok(list);

        }

        [HttpPut("Update")]
        public IActionResult Update(int id, HotelesViewModel items)
        {

            var item = _mapper.Map<tbHoteles>(items);
            var result = _hotelService.UpdateHotel(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _hotelService.DeleteHotel(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            var result = _hotelService.FindHotel(Id);
            return Ok(result);
        }

    }
}
