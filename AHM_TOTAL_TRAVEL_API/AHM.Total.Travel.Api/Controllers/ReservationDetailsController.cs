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
    public class ReservationDetailsController : Controller
    {
        private readonly ReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationDetailsController(ReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _reservationService.ListReservationDetails();
            return Ok(list);
        }

        [HttpPost("Create")]
        public IActionResult Create(ReservacionesDetallesViewModel item)
        {
            var items = _mapper.Map<tbReservacionesDetalles>(item);
            var result = _reservationService.CreateReservationDetails(items);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, ReservacionesDetallesViewModel items)
        {
            var item = _mapper.Map<tbReservacionesDetalles>(items);
            var result = _reservationService.UpdateReservationDetails(id, item);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id, int Mod)
        {
            var result = _reservationService.DeleteReservationDetails(id, Mod);
            return Ok(result);
        }

        [HttpGet("Find")]
        public IActionResult Find(int id)
        {
            var list = _reservationService.FindReservationDetails(id);
            return Ok(list);
        }

    }
}
