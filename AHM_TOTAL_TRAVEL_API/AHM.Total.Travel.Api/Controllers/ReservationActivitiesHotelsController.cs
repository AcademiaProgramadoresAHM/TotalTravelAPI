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
    [Route("API/[controller]")]
    public class ReservationActivitiesHotelsController : Controller
    {
        private readonly ReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationActivitiesHotelsController(ReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _reservationService.ListReservationActivitiesHotels();
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(ReservacionesActividadesHotelesViewModel item)
        {
            var items = _mapper.Map<tbReservacionesActividadesHoteles>(item);
            var result = _reservationService.CreateReservationActivitiesHotels(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, ReservacionesActividadesHotelesViewModel items)
        {
            var item = _mapper.Map<tbReservacionesActividadesHoteles>(items);
            var result = _reservationService.UpdateReservationActivitiesHotels(id, item);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _reservationService.DeleteReservationActivitiesHotels(id, Mod);
            return Ok(result);
        }

        [HttpGet("Find")]
        public IActionResult Find(int id)
        {
            var list = _reservationService.FindReservationActivitiesHotels(id);
            return Ok(list);
        }

    }
}
