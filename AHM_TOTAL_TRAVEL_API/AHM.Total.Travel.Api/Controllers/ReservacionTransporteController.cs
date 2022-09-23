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
    [Route(" [Controller] ")]
    public class ReservacionTransporteController : Controller
    {
        private readonly ReservationService _reservationService;
        private readonly IMapper _mapper;
        public ReservacionTransporteController(ReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _reservationService.ListReservationTransport();
            return Ok(list);

        }

        [HttpPut("Update")]
        public IActionResult Update(int id, ReservacionTransporteViewModel items)
        {

            var item = _mapper.Map<tbReservacionTransporte>(items);
            var result = _reservationService.UpdateReservationTransport(id, item);
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _reservationService.DeleteReservationTransport(id, Mod);
            return Ok(result);

        }

        [HttpGet("Find")]
        public IActionResult Details(int Id)
        {
            var result = _reservationService.FindReservationTransport(Id);
            return Ok(result);
        }
    }
}
