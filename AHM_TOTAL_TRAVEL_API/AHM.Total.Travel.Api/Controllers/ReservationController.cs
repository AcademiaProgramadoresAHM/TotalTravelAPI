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
    [Authorize(Roles = "Administrador, Cliente")]
    public class ReservationController : Controller
    {
        private readonly ReservationService _reservationService;
        private readonly IMapper _mapper;
        public ReservationController(ReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _reservationService.ListReservation();
            return Ok(list);
        }

        [Authorize(Roles = "Administrador, Cliente")]
        [HttpPost("Insert")]
        public IActionResult Insert(ReservacionesViewModel item)
        {
            var items = _mapper.Map<tbReservaciones>(item);
            var result = _reservationService.CreateReservation(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, ReservacionesViewModel items)
        {
            var item = _mapper.Map<tbReservaciones>(items);
            var result = _reservationService.UpdateReservation(id, item);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _reservationService.DeleteReservation(id, Mod);
            return Ok(result);
        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            var result = _reservationService.FindReservation(Id);
            return Ok(result);
        }
    }
}
