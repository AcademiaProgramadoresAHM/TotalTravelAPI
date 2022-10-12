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
    [Route("API/[Controller]")]
    [Authorize(Roles = "Administrador, Cliente")]
    public class ReservationRestaurantController : Controller
    {
        private readonly ReservationService  _reservationService;
        private readonly IMapper _mapper;
        public ReservationRestaurantController(ReservationService  reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [AllowAnonymous]

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _reservationService.ListReservationRestaurant();
            return Ok(list);

        }

        [AllowAnonymous]

        [HttpPost("Insert")]
        public IActionResult Insert( ReservacionRestaurantesViewModel items)
        {

            var item = _mapper.Map<tbReservacionRestaurantes>(items);
            var result = _reservationService.CreateReservationRestaurant(item);
            return Ok(result);

        }

        [AllowAnonymous]

        [HttpPut("Update")]
        public IActionResult Update(int id, ReservacionRestaurantesViewModel items)
        {

            var item = _mapper.Map<tbReservacionRestaurantes>(items);
            var result = _reservationService.UpdateReservationRestaurant(id, item);
            return Ok(result);

        }
        [AllowAnonymous]


        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _reservationService.DeleteReservationRestaurant(id, Mod);
            return Ok(result);

        }

        [AllowAnonymous]

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            var result = _reservationService.FindReservationRestaurant(Id);
            return Ok(result);
        }
    }
}
