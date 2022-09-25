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
    public class ReservationHotelsController : Controller
    {
        
        private readonly ReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationHotelsController(ReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _reservationService.ListReservationHotel();
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(ReservacionesHotelesViewModel item)
        {
            var items = _mapper.Map<tbReservacionesHoteles>(item);
            var result = _reservationService.CreateReservationHotel(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, ReservacionesHotelesViewModel items)
        {
            var item = _mapper.Map<tbReservacionesHoteles>(items);
            var result = _reservationService.UpdateReservationHotel(id, item);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _reservationService.DeleteReservationHotel(id, Mod);
            return Ok(result);
        }

        [HttpGet("Find")]
        public IActionResult Find(int id)
        {
            var result = _reservationService.FindReservationHotel(id);
            return Ok(result);
        }

    }
}
