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
    public class ReservationActivitiesExtraController : Controller
    {
        private readonly ReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationActivitiesExtraController(ReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _reservationService.ListReservationActivitiesExtra();
            return Ok(list);
        }

        [Authorize(Roles = "Administrador, Cliente")]
        [HttpPost("Insert")]
        public IActionResult Insert(ReservacionesActividadesExtrasViewModel item)
        {
            var items = _mapper.Map<tbReservacionesActividadesExtras>(item);
            var result = _reservationService.CreateReservationActivitiesExtra(items);
            return Ok(result);
        }


        [HttpPut("Update")]
        public IActionResult Update(int id, ReservacionesActividadesExtrasViewModel items)
        {
            var item = _mapper.Map<tbReservacionesActividadesExtras>(items);
            var result = _reservationService.UpdateReservationActivitiesExtra(id, item);
            return Ok(result);
        }


        
        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _reservationService.DeleteReservationActivitiesExtra(id, Mod);
            return Ok(result);
        }


        [HttpGet("Find")]
        [Authorize(Roles = "Administrador, Cliente")]
        public IActionResult Find(int id)
        {
            var item = _reservationService.FindReservationActivitiesExtra(id);
            return Ok(item);
        }

    }
}
